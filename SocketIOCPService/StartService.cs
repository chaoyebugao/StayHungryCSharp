using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SocketSAEA
{
    class StartService
    {
        public void Run()
        {
            var serverSocket = new ServerSocketManager(100, 1024);
            serverSocket.Init();
            serverSocket.Start(new IPEndPoint(IPAddress.Any, 13909));
            serverSocket.ClientNumberChange += ServerOnClientNumberChange;
            serverSocket.ReceiveClientData += ServerOnReceiveData;

            Console.WriteLine("[Server]启动完毕");
            
        }

        private void ServerOnClientNumberChange(int num, AsyncUserToken user)
        {
            Console.WriteLine($"client num changed:{num}");
        }

        int revCount = 0;
        private void ServerOnReceiveData(AsyncUserToken user, byte[] buff)
        {
            revCount++;
            string content = Encoding.UTF8.GetString(buff);
            Console.WriteLine($"{revCount}:{content}");
        }
    }
}
