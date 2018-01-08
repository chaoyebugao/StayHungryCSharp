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
    class Program
    {
        static void Main(string[] args)
        {
            var socketServer = new SocketServer();
            socketServer.Run();

            Console.Read();

        }

        

        
    }
}
