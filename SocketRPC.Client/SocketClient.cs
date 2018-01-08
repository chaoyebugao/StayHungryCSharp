using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketThreadBase.Client
{
    class SocketClient
    {
        //使用IPv4地址，流式socket方式，tcp协议传递数据
        Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public void Run()
        {
            //连接到目标IP
            var ip = IPAddress.Parse("127.0.0.1");
            //链接到目标端口
            var point = new IPEndPoint(ip, 9000);

            try
            {
                clientSocket.Connect(point);
                Console.WriteLine("[客户端]");
                Console.WriteLine($"链接成功，服务端：{clientSocket.RemoteEndPoint.ToString()}，客户端：{clientSocket.LocalEndPoint.ToString()}");
                
                var thread = new Thread(HandleMessage);
                thread.IsBackground = true;
                thread.Start(clientSocket);

                string words = $"Anyone?{DateTime.Now.ToString("yyyy - MM - dd HH: mm: ss,fff")}";
                var buffer = Encoding.UTF8.GetBytes(words);
                clientSocket.Send(buffer);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        void HandleMessage(object socket)
        {
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[1024 * 1024];
                    int n = clientSocket.Receive(buffer);
                    string words = Encoding.UTF8.GetString(buffer, 0, n);

                    Console.WriteLine($"客户端收到{clientSocket.RemoteEndPoint.ToString()}消息:【{words}】，时间：{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,fff")}");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                    break;
                }
            }
        }
    }
}
