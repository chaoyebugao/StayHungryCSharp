using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1.线程
{
    class SleepAndWait
    {


        public static void Exec1()
        {
            var obj = new object();
            int i = 0;

            var t1 = new Thread(() =>
            {
                Console.WriteLine(i);
                i++;
            });

            var t2 = new Thread(() =>
            {
                Console.WriteLine(i);
                i++;
            });

            var t3 = new Thread(() =>
            {
                Console.WriteLine(i);
                i++;
            });

            var t4 = new Thread(() =>
            {
                Console.WriteLine(i);
                i++;
            });

            var t5 = new Thread(() =>
            {
                Console.WriteLine(i);
                i++;
            });


            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            t5.Start();



            Console.Read();
        }

        public static void Exec2()
        {
            int i = 0;
            var t1 = new Task(() =>
            {
                i = 0;
                for (int j = 0; i < 100; j++)
                {
                    i++;
                    Console.WriteLine("t1:" + i);
                }

            });

            var t2 = new Task(() =>
            {
                i = 0;
                for (int j = 0; i < 100; j++)
                {
                    i++;
                    Console.WriteLine("t2:" + i);
                }

            });

            t1.Start();
            //t1.Wait();
            Console.WriteLine("t1 waited");

            t2.Start();
            //t2.Wait();
            Console.WriteLine("t2 waited");

            Console.Read();
        }
    }
}
