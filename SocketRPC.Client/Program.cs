using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketRPC.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(3000);

            var socketClient = new SocketClient();
            socketClient.Run();


            Console.Read();
        }
    }
}
