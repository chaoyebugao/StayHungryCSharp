using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AsyncAndThreading.多线程
{
    static class 多线程静态
    {
        [ThreadStatic]
        static int i = 3;

        public static void ChangePrintVal(string from)
        {
            i++;
            Console.WriteLine(from + ", i = " + i);
        }

        public static void Exec()
        {
            var t1 = new Thread(() =>
            {
                ChangePrintVal("t1's tid: " + Thread.CurrentThread.ManagedThreadId);
            });
            t1.Start();

            var t2 = new System.Threading.Thread(() =>
            {
                ChangePrintVal("t2's tid: " + Thread.CurrentThread.ManagedThreadId);
            });
            t2.Start();
        }
    }
}
