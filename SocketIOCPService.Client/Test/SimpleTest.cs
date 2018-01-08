﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SocketSAEA.Client.Test
{
    class SimpleTest
    {
        public void Exec()
        {
            

            Console.WriteLine("回车开始发送...");
            Console.ReadLine();

            Request.Connect();
            Request.Send("有人吗？");

            Console.WriteLine("回车结束程序...");
            Console.ReadLine();
        }

        private static void ServerOnReceiveData(AsyncUserToken user, byte[] buff)
        {
            Console.WriteLine(Encoding.UTF8.GetString(buff));
        }
    }
}
