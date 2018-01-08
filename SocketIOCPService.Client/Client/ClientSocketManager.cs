using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketSAEA.Client
{
    /// <summary>
    /// 客户端管理
    /// 参考：http://freshflower.iteye.com/blog/2285286
    /// </summary>
    class ClientSocketManager : IDisposable
    {
        private const Int32 BuffSize = 1024;

        // The socket used to send/receive messages.  
        private Socket clientSocket;

        // Flag for connected socket.  
        private Boolean connected = false;

        // Listener endpoint.  
        private IPEndPoint hostEndPoint;

        // Signals a connection.  
        private static AutoResetEvent autoConnectEvent = new AutoResetEvent(false);

        BufferManager bufferManager;
        //定义接收数据的对象  
        List<byte> buffer;
        //TODO:去掉public
        //发送与接收的MySocketEventArgs变量定义.  
        public List<MySocketEventArgs> listArgs = new List<MySocketEventArgs>();
        private MySocketEventArgs receiveEventArgs = new MySocketEventArgs();
        int tagCount = 0;

        /// <summary>  
        /// 当前连接状态  
        /// </summary>  
        public bool Connected
        {
            get
            {
                return clientSocket != null && clientSocket.Connected;
            }
        }

        //服务器主动发出数据受理委托及事件  
        public delegate void OnServerDataReceived(byte[] receiveBuff);
        public event OnServerDataReceived ServerDataHandler;

        //服务器主动关闭连接委托及事件  
        public delegate void OnServerStop();
        public event OnServerStop ServerStopEvent;


        // Create an uninitialized client instance.  
        // To start the send/receive processing call the  
        // Connect method followed by SendReceive method.  
        internal ClientSocketManager(String ip, Int32 port)
        {
            // Instantiates the endpoint and socket.  
            hostEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            clientSocket = new Socket(hostEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            bufferManager = new BufferManager(BuffSize * 2, BuffSize);
            buffer = new List<byte>();
        }

        /// <summary>  
        /// 连接到主机  
        /// </summary>  
        /// <returns>0.连接成功, 其他值失败,参考SocketError的值列表</returns>  
        internal SocketError Connect()
        {
            var connectArgs = new SocketAsyncEventArgs();
            connectArgs.UserToken = clientSocket;
            connectArgs.RemoteEndPoint = hostEndPoint;
            connectArgs.Completed += new EventHandler<SocketAsyncEventArgs>(OnConnect);

            clientSocket.ConnectAsync(connectArgs);
            autoConnectEvent.WaitOne(); //阻塞. 让程序在这里等待,直到连接响应后再返回连接结果  
            return connectArgs.SocketError;
        }

        /// Disconnect from the host.  
        internal void Disconnect()
        {
            clientSocket.Disconnect(false);
        }

        // Calback for connect operation  
        private void OnConnect(object sender, SocketAsyncEventArgs e)
        {
            // Signals the end of connection.  
            autoConnectEvent.Set(); //释放阻塞.  
            // Set the flag for socket connected.  
            connected = (e.SocketError == SocketError.Success);
            //如果连接成功,则初始化socketAsyncEventArgs  
            if (connected)
                InitArgs(e);
        }


        #region args  

        /// <summary>  
        /// 初始化收发参数  
        /// </summary>  
        /// <param name="e"></param>  
        private void InitArgs(SocketAsyncEventArgs e)
        {
            bufferManager.InitBuffer();
            //发送参数  
            InitSendArgs();
            //接收参数  
            receiveEventArgs.Completed += new EventHandler<SocketAsyncEventArgs>(IO_Completed);
            receiveEventArgs.UserToken = e.UserToken;
            receiveEventArgs.ArgsTag = 0;
            bufferManager.SetBuffer(receiveEventArgs);

            //启动接收,不管有没有,一定得启动.否则有数据来了也不知道.  
            if (!e.ConnectSocket.ReceiveAsync(receiveEventArgs))
                ProcessReceive(receiveEventArgs);
        }

        /// <summary>  
        /// 初始化发送参数MySocketEventArgs  
        /// </summary>  
        /// <returns></returns>  
        MySocketEventArgs InitSendArgs()
        {
            var sendArg = new MySocketEventArgs();
            sendArg.Completed += new EventHandler<SocketAsyncEventArgs>(IO_Completed);
            sendArg.UserToken = clientSocket;
            sendArg.RemoteEndPoint = hostEndPoint;
            sendArg.IsUsing = false;
            Interlocked.Increment(ref tagCount);
            sendArg.ArgsTag = tagCount;
            lock (listArgs)
            {
                listArgs.Add(sendArg);
            }
            return sendArg;
        }

        void IO_Completed(object sender, SocketAsyncEventArgs e)
        {
            var mySckEvntArgs = (MySocketEventArgs)e;
            mySckEvntArgs.IsUsing = false; //数据发送已完成.状态设为False  
            
            // determine which type of operation just completed and call the associated handler  
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.Receive:
                    ProcessReceive(e);
                    break;
                case SocketAsyncOperation.Send:
                    ProcessSend(e);
                    break;
                case SocketAsyncOperation.Disconnect:
                    listArgs.Remove(mySckEvntArgs);
                    break;
                default:
                    throw new ArgumentException("The last operation completed on the socket was not a receive or send");
            }
        }

        // This method is invoked when an asynchronous receive operation completes.   
        // If the remote host closed the connection, then the socket is closed.    
        // If data was received then the data is echoed back to the client.  
        //  
        private void ProcessReceive(SocketAsyncEventArgs e)
        {
            try
            {
                // check if the remote host closed the connection  
                Socket token = (Socket)e.UserToken;
                if (e.BytesTransferred > 0 && e.SocketError == SocketError.Success)
                {
                    //读取数据  
                    byte[] data = new byte[e.BytesTransferred];
                    Array.Copy(e.Buffer, e.Offset, data, 0, e.BytesTransferred);
                    lock (buffer)
                    {
                        buffer.AddRange(data);
                    }

                    do
                    {
                        //注意: 这里是需要和服务器有协议的,我做了个简单的协议,就是一个完整的包是包长(4字节)+包数据,便于处理,当然你可以定义自己需要的;   
                        //判断包的长度,前面4个字节.  
                        byte[] lenBytes = buffer.GetRange(0, 4).ToArray();
                        int packageLen = BitConverter.ToInt32(lenBytes, 0);
                        if (packageLen <= buffer.Count - 4)
                        {
                            //包够长时,则提取出来,交给后面的程序去处理  
                            byte[] rev = buffer.GetRange(4, packageLen).ToArray();
                            //从数据池中移除这组数据,为什么要lock,你懂的  
                            lock (buffer)
                            {
                                buffer.RemoveRange(0, packageLen + 4);
                            }
                            //将数据包交给前台去处理  
                            DoReceiveEvent(rev);
                        }
                        else
                        {   //长度不够,还得继续接收,需要跳出循环  
                            break;
                        }
                    } while (buffer.Count > 4);
                    //注意:你一定会问,这里为什么要用do-while循环?     
                    //如果当服务端发送大数据流的时候,e.BytesTransferred的大小就会比服务端发送过来的完整包要小,    
                    //需要分多次接收.所以收到包的时候,先判断包头的大小.够一个完整的包再处理.    
                    //如果服务器短时间内发送多个小数据包时, 这里可能会一次性把他们全收了.    
                    //这样如果没有一个循环来控制,那么只会处理第一个包,    
                    //剩下的包全部留在m_buffer中了,只有等下一个数据包过来后,才会放出一个来.  
                    //继续接收  
                    if (!token.ReceiveAsync(e))
                        this.ProcessReceive(e);
                }
                else
                {
                    ProcessError(e);
                }
            }
            catch (Exception xe)
            {
                Console.WriteLine(xe.Message);
            }
        }

        // This method is invoked when an asynchronous send operation completes.    
        // The method issues another receive on the socket to read any additional   
        // data sent from the client  
        //  
        // <param name="e"></param>  
        private void ProcessSend(SocketAsyncEventArgs e)
        {
            if (e.SocketError != SocketError.Success)
            {
                ProcessError(e);
            }
        }

        #endregion

        #region read write  

        // Close socket in case of failure and throws  
        // a SockeException according to the SocketError.  
        private void ProcessError(SocketAsyncEventArgs e)
        {
            Socket s = (Socket)e.UserToken;
            if (s.Connected)
            {
                // close the socket associated with the client  
                try
                {
                    s.Shutdown(SocketShutdown.Both);
                }
                catch (Exception)
                {
                    // throws if client process has already closed  
                }
                finally
                {
                    if (s.Connected)
                    {
                        s.Close();
                    }
                    connected = false;
                }
            }
            //这里一定要记得把事件移走,如果不移走,当断开服务器后再次连接上,会造成多次事件触发.  
            foreach (MySocketEventArgs arg in listArgs)
            {
                arg.Completed -= IO_Completed;
            }
            receiveEventArgs.Completed -= IO_Completed;

            if (ServerStopEvent != null)
            {
                ServerStopEvent();
            }
        }

        

        // Exchange a message with the host.  
        internal void Send(byte[] sendBuffer)
        {
            if (connected)
            {
                //先对数据进行包装,就是把包的大小作为头加入,这必须与服务器端的协议保持一致,否则造成服务器无法处理数据.  
                byte[] buff = new byte[sendBuffer.Length + 4];
                Array.Copy(BitConverter.GetBytes(sendBuffer.Length), buff, 4);
                Array.Copy(sendBuffer, 0, buff, 4, sendBuffer.Length);
                //查找有没有空闲的发送MySocketEventArgs,有就直接拿来用,没有就创建新的.So easy!  
                var sendArgs = listArgs.Find(a => a.IsUsing == false);
                if (sendArgs == null)
                {
                    sendArgs = InitSendArgs();
                }

                try
                {
                    lock (sendArgs) //要锁定,不锁定让别的线程抢走了就不妙了.  
                    {
                        sendArgs.IsUsing = true;
                        sendArgs.SetBuffer(buff, 0, buff.Length);
                    }

                    clientSocket.SendAsync(sendArgs);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }



            }
            else
            {
                throw new SocketException((Int32)SocketError.NotConnected);
            }
        }

        /// <summary>  
        /// 使用新进程通知事件回调  
        /// </summary>  
        /// <param name="buff"></param>  
        private void DoReceiveEvent(byte[] buff)
        {
            if (ServerDataHandler == null) return;
            //ServerDataHandler(buff); //可直接调用.  
            //但我更喜欢用新的线程,这样不拖延接收新数据.  
            var thread = new Thread(new ParameterizedThreadStart((obj) =>
            {
                ServerDataHandler((byte[])obj);
            }));
            thread.IsBackground = true;
            thread.Start(buff);
        }

        #endregion

        #region IDisposable Members  

        // Disposes the instance of SocketClient.  
        public void Dispose()
        {
            autoConnectEvent.Close();
            if (clientSocket.Connected)
            {
                clientSocket.Close();
            }
        }

        #endregion
    }
}
