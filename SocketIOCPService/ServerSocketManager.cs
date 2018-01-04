using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketIOCPService
{
    /// <summary>
    /// 实现Socket监听,收发信息等
    /// </summary>
    class ServerSocketManager
    {
        //最大连接数
        int maxConnectionNum;
        //最大接收字节数
        int revBufferSize;
        //缓存数据大小管理
        BufferManager bufferManager;
        const int opsToAlloc = 2;
        //监听Socket
        Socket listenSocket;
        SocketEventPool eventPool;
        //连接的客户端数量
        int clientCount;
        Semaphore maxNumerAcceptedClients;

        //客户端列表
        IList<AsyncUserToken> clients;

        /// <summary>
        /// 客户端列表
        /// </summary>
        public IList<AsyncUserToken> Clients
        {
            get
            {
                return this.clients;
            }
        }

        #region 定义委托
        /// <summary>
        /// 客户端链接数量变化时出发
        /// </summary>
        /// <param name="num">当前增加客户的个数（用户退出时为负数，增加为整数，一般为1）</param>
        /// <param name="user">增加用户的信息</param>
        public delegate void OnClientNumberChange(int num, AsyncUserToken user);

        /// <summary>
        /// 接收到客户端的数据
        /// </summary>
        /// <param name="user">客户端信息</param>
        /// <param name="buff">客户端数据</param>
        public delegate void OnReceiveData(AsyncUserToken user, byte[] buff);

        #endregion

        #region 定义事件
        /// <summary>
        /// 客户端链接数量变化事件
        /// </summary>
        public event OnClientNumberChange ClientNumberChange;

        /// <summary>
        /// 接收到客户端的数据事件
        /// </summary>
        public event OnReceiveData ReceiveClientData;
        #endregion

        /// <summary>
        /// 创建实例
        /// </summary>
        /// <param name="maxConnectionNum">最大链接数</param>
        /// <param name="receiveBufferSize">缓冲区大小</param>
        public ServerSocketManager(int maxConnectionNum, int receiveBufferSize)
        {
            clientCount = 0;
            this.maxConnectionNum = maxConnectionNum;
            this.revBufferSize = receiveBufferSize;
            var totalBytesLength = this.revBufferSize * this.maxConnectionNum * opsToAlloc;
            //分配缓冲区，这样大数量的Socket可以同时有突出的到Socket的读写
            bufferManager = new BufferManager(totalBytesLength, this.revBufferSize);
            eventPool = new SocketEventPool(this.maxConnectionNum);
            maxNumerAcceptedClients = new Semaphore(this.maxConnectionNum, this.maxConnectionNum);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            //分配一大片I/O操作使用的缓冲区，这样就避免了内存碎片化
            bufferManager.InitBuffer();
            clients = new List<AsyncUserToken>();

            //提前分配SocketAsyncEventArgs对象的pool
            SocketAsyncEventArgs readWriteEventArg;
            for (int i = 0; i < maxConnectionNum; i++)
            {
                readWriteEventArg = new SocketAsyncEventArgs();
                readWriteEventArg.Completed += new EventHandler<SocketAsyncEventArgs>(IO_Completed);
                readWriteEventArg.UserToken = new AsyncUserToken();

                //从Buffer池给SocketAsyncEventArgs对象分配buffer
                bufferManager.SetBuffer(readWriteEventArg);
                //将SocketAsyncEventArg添加到Event池中
                eventPool.Push(readWriteEventArg);
            }
        }

        /// <summary>  
        /// 启动服务  
        /// </summary>  
        /// <param name="localEndPoint"></param>  
        public bool Start(IPEndPoint localEndPoint)
        {
            try
            {
                clients.Clear();
                listenSocket = new Socket(localEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                listenSocket.Bind(localEndPoint);
                // 开始监听
                listenSocket.Listen(this.maxConnectionNum);
                //开始接受数据 
                StartAccept(null);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>  
        /// 停止服务  
        /// </summary>  
        public void Stop()
        {
            foreach (AsyncUserToken token in clients)
            {
                try
                {
                    token.Socket.Shutdown(SocketShutdown.Both);
                }
                catch (Exception)
                {
                }
            }
            try
            {
                listenSocket.Shutdown(SocketShutdown.Both);
            }
            catch (Exception) { }

            listenSocket.Close();
            int c_count = clients.Count;
            lock (clients)
            {
                clients.Clear();
            }

            if (ClientNumberChange != null)
            {
                ClientNumberChange(-c_count, null);
            }
        }

        /// <summary>
        /// 关闭指定客户端
        /// </summary>
        /// <param name="token"></param>
        public void CloseClient(AsyncUserToken token)
        {
            try
            {
                token.Socket.Shutdown(SocketShutdown.Both);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 开始接受客户端链接请求过来的数据
        /// </summary>
        /// <param name="acceptEventArg">用于接受数据的发行的上下文类</param>
        public void StartAccept(SocketAsyncEventArgs acceptEventArg)
        {
            if (acceptEventArg == null)
            {
                acceptEventArg = new SocketAsyncEventArgs();
                acceptEventArg.Completed += new EventHandler<SocketAsyncEventArgs>(AcceptEventArg_Completed);
            }
            else
            {
                //被重用过的上下文类必须清零
                acceptEventArg.AcceptSocket = null;
            }

            this.maxNumerAcceptedClients.WaitOne();
            if (!listenSocket.AcceptAsync(acceptEventArg))
            {
                ProcessAccept(acceptEventArg);
            }
        }

        // This method is the callback method associated with Socket.AcceptAsync   
        // operations and is invoked when an accept operation is complete  
        //  
        void AcceptEventArg_Completed(object sender, SocketAsyncEventArgs e)
        {
            ProcessAccept(e);
        }

        private void ProcessAccept(SocketAsyncEventArgs e)
        {
            try
            {
                Interlocked.Increment(ref clientCount);
                // Get the socket for the accepted client connection and put it into the   
                //ReadEventArg object user token  
                SocketAsyncEventArgs readEventArgs = eventPool.Pop();
                AsyncUserToken userToken = (AsyncUserToken)readEventArgs.UserToken;
                userToken.Socket = e.AcceptSocket;
                userToken.ConnectTime = DateTime.Now;
                userToken.Remote = e.AcceptSocket.RemoteEndPoint;
                userToken.IPAddress = ((IPEndPoint)(e.AcceptSocket.RemoteEndPoint)).Address;

                lock (clients)
                {
                    clients.Add(userToken);
                }

                if (ClientNumberChange != null)
                {
                    ClientNumberChange(1, userToken);
                }

                if (!e.AcceptSocket.ReceiveAsync(readEventArgs))
                {
                    ProcessReceive(readEventArgs);
                }
            }
            catch (Exception me)
            {
                //TODO:LOG
                //RuncomLib.Log.LogUtils.Info(me.Message + "\r\n" + me.StackTrace);
            }

            // Accept the next connection request  
            if (e.SocketError == SocketError.OperationAborted)
            {
                return;
            }
            StartAccept(e);
        }


        void IO_Completed(object sender, SocketAsyncEventArgs e)
        {
            // determine which type of operation just completed and call the associated handler  
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.Receive:
                    ProcessReceive(e);
                    break;
                case SocketAsyncOperation.Send:
                    ProcessSend(e);
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
                var token = (AsyncUserToken)e.UserToken;
                if (e.BytesTransferred > 0 && e.SocketError == SocketError.Success)
                {
                    //读取数据  
                    byte[] data = new byte[e.BytesTransferred];
                    Array.Copy(e.Buffer, e.Offset, data, 0, e.BytesTransferred);
                    lock (token.Buffer)
                    {
                        token.Buffer.AddRange(data);
                    }

                    //如果当客户发送大数据流的时候,e.BytesTransferred的大小就会比客户端发送过来的要小,  
                    //需要分多次接收.所以收到包的时候,先判断包头的大小.够一个完整的包再处理.  
                    //如果客户短时间内发送多个小数据包时, 服务器可能会一次性把他们全收了.  
                    //这样如果没有一个循环来控制,那么只会处理第一个包,  
                    //剩下的包全部留在token.Buffer中了,只有等下一个数据包过来后,才会放出一个来.  
                    do
                    {
                        //判断包的长度  
                        var lenBytes = token.Buffer.GetRange(0, 4).ToArray();
                        var packageLen = BitConverter.ToInt32(lenBytes, 0);
                        if (packageLen > token.Buffer.Count - 4)
                        {   //长度不够时,退出循环,让程序继续接收  
                            break;
                        }

                        //包够长时,则提取出来,交给后面的程序去处理  
                        var rev = token.Buffer.GetRange(4, packageLen).ToArray();
                        //从数据池中移除这组数据  
                        lock (token.Buffer)
                        {
                            token.Buffer.RemoveRange(0, packageLen + 4);
                        }
                        //将数据包交给后台处理,这里你也可以新开个线程来处理.加快速度.  
                        if (ReceiveClientData != null)
                        {
                            ReceiveClientData(token, rev);
                        }

                        //这里API处理完后,并没有返回结果,当然结果是要返回的,却不是在这里, 这里的代码只管接收.  
                        //若要返回结果,可在API处理中调用此类对象的SendMessage方法,统一打包发送.不要被微软的示例给迷惑了.  
                    } while (token.Buffer.Count > 4);

                    //继续接收. 为什么要这么写,请看Socket.ReceiveAsync方法的说明  
                    if (!token.Socket.ReceiveAsync(e))
                    {
                        this.ProcessReceive(e);
                    }

                }
                else
                {
                    CloseClientSocket(e);
                }
            }
            catch (Exception xe)
            {
                //TODO:LOG
                //RuncomLib.Log.LogUtils.Info(xe.Message + "\r\n" + xe.StackTrace);
            }
        }

        // This method is invoked when an asynchronous send operation completes.    
        // The method issues another receive on the socket to read any additional   
        // data sent from the client  
        //  
        // <param name="e"></param>  
        private void ProcessSend(SocketAsyncEventArgs e)
        {
            if (e.SocketError == SocketError.Success)
            {
                // done echoing data back to the client  
                AsyncUserToken token = (AsyncUserToken)e.UserToken;
                // read the next block of data send from the client  
                bool willRaiseEvent = token.Socket.ReceiveAsync(e);
                if (!willRaiseEvent)
                {
                    ProcessReceive(e);
                }
            }
            else
            {
                CloseClientSocket(e);
            }
        }

        //关闭客户端  
        private void CloseClientSocket(SocketAsyncEventArgs e)
        {
            AsyncUserToken token = e.UserToken as AsyncUserToken;

            lock (clients) { clients.Remove(token); }
            //如果有事件,则调用事件,发送客户端数量变化通知  
            if (ClientNumberChange != null)
                ClientNumberChange(-1, token);
            // close the socket associated with the client  
            try
            {
                token.Socket.Shutdown(SocketShutdown.Send);
            }
            catch (Exception) { }
            token.Socket.Close();
            // decrement the counter keeping track of the total number of clients connected to the server  
            Interlocked.Decrement(ref clientCount);
            this.maxNumerAcceptedClients.Release();
            // Free the SocketAsyncEventArg so they can be reused by another client  
            e.UserToken = new AsyncUserToken();
            eventPool.Push(e);
        }



        /// <summary>  
        /// 对数据进行打包,然后再发送  
        /// </summary>  
        /// <param name="token"></param>  
        /// <param name="message"></param>  
        /// <returns></returns>  
        public void SendMessage(AsyncUserToken token, byte[] message)
        {
            if (token == null || token.Socket == null || !token.Socket.Connected)
                return;
            try
            {
                //对要发送的消息,制定简单协议,头4字节指定包的大小,方便客户端接收(协议可以自己定)  
                byte[] buff = new byte[message.Length + 4];
                byte[] len = BitConverter.GetBytes(message.Length);
                Array.Copy(len, buff, 4);
                Array.Copy(message, 0, buff, 4, message.Length);
                //token.Socket.Send(buff);  //这句也可以发送, 可根据自己的需要来选择  
                //新建异步发送对象, 发送消息  
                SocketAsyncEventArgs sendArg = new SocketAsyncEventArgs();
                sendArg.UserToken = token;
                sendArg.SetBuffer(buff, 0, buff.Length);  //将数据放置进去.  
                token.Socket.SendAsync(sendArg);
            }
            catch (Exception e)
            {
                //TODO:LOG
                //RuncomLib.Log.LogUtils.Info("SendMessage - Error:" + e.Message);
            }
        }



    }
}
