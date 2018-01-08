using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketThreadBase.Server
{
    class SocketServer
    {
        //使用IPv4地址，流式socket方式，tcp协议传递数据
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public void Run()
        {
            //ip地址
            var ip = IPAddress.Parse("127.0.0.1");
            //端口号
            var point = new IPEndPoint(ip, 9000);
            

            try
            {
                //socket监听哪个端口
                serverSocket.Bind(point);
                //同一个时间点过来10个客户端，排队
                serverSocket.Listen(10);
                Console.WriteLine("[服务端]");
                Console.WriteLine("服务已开始监听");
                var thread = new Thread(AcceptConnection);
                thread.IsBackground = true;
                thread.Start(serverSocket);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //记录通信用的Socket
        IDictionary<string, Socket> clientDict = new Dictionary<string, Socket>();

        void AcceptConnection(object socket)
        {
            var serverSocket = socket as Socket;

            while (true)
            {
                try
                {
                    //创建通信用的Socket
                    var clientSokcet = serverSocket.Accept();
                    var clientEndPoint = clientSokcet.RemoteEndPoint.ToString();

                    Console.WriteLine($"{clientEndPoint}链接成功");
                    clientDict.Add(clientEndPoint, clientSokcet);

                    //接收消息
                    var thread = new Thread(HandleMessage);
                    thread.IsBackground = true;
                    thread.Start(clientSokcet);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    break;
                }
            }

        }

        void HandleMessage(object socket)
        {
            var clientSokcet = socket as Socket;


            while (true)
            {
                //接收客户端发送过来的数据
                try
                {
                    //定义byte数组存放从客户端接收过来的数据
                    byte[] buffer = new byte[1024 * 1024];

                    //将接收过来的数据放到buffer中，并返回实际接受数据的长度
                    int n = clientSokcet.Receive(buffer);

                    //将字节转换成字符串
                    string words = Encoding.UTF8.GetString(buffer, 0, n);

                    Console.WriteLine($"服务端收到{clientSokcet.RemoteEndPoint.ToString()}消息:【{words}】，时间:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,fff")}");
                    
                    string wordsReply = $"I'm here.{DateTime.Now.ToString("yyyy - MM - dd HH: mm: ss,fff")}";
                    var bufferReply = Encoding.UTF8.GetBytes(wordsReply);
                    clientSokcet.Send(bufferReply);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    break;
                }
            }


        }



    }
}
