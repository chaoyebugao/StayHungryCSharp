﻿using SocketSAEA.Client.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketSAEA.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("回车开始运行");
            //Console.ReadLine();

            new SingleClientTest().Exec();

            Console.ReadLine();
        }
    }
}
