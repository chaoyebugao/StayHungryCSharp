using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketIOCPService
{
    class Program
    {
        static void Main(string[] args)
        {
            var serverSocket = new ServerSocketManager(200, 1024);
            serverSocket.Init();
            serverSocket.Start(new IPEndPoint(IPAddress.Any, 13909));

            serverSocket.ReceiveClientData += ServerOnReceiveData;

            Console.WriteLine("回车开始发送...");
            Console.ReadLine();

            RequestTest.Connect();
            RequestTest.Send("有人吗？");

            Console.WriteLine("回车结束程序...");
            Console.ReadLine();
            

        }

        private static void ServerOnReceiveData(AsyncUserToken user, byte[] buff)
        {
            Console.WriteLine(Encoding.UTF8.GetString(buff));
        }

        
    }
}
