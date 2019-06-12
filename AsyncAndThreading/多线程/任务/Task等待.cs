using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndThreading.多线程.任务
{
    public class Task等待
    {
        public static async Task Exec()
        {
            var r1 = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("I'm task1");
            });
            r1.GetAwaiter().OnCompleted(() =>
            {
                Console.WriteLine("task1 完成了");
            });
            //r1.Wait();
            

            var r2 = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("I'm task2");
            });
            r2.GetAwaiter().OnCompleted(() =>
            {
                Console.WriteLine("task2 完成了");
            });
            //r2.Wait();
            

            Console.WriteLine("主线程要结束了");

            Console.ReadKey();
        }
    }
}
