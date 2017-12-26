using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.多线程.任务
{
    class MTTask
    {
        public static void Exe()
        {
            Task t = new Task(() =>
            {
                Console.WriteLine("here");
                throw new Exception("任务并行编码中产生的未知异常");
            });
            t.Start();
            var tExHandler = t.ContinueWith((task) =>
            {
                foreach (var item in task.Exception.InnerExceptions)
                {
                    Console.WriteLine("异常类型：{0}{1}，来自：{2}{3}，异常内容：{4}",
                        item.GetType(), Environment.NewLine,
                        item.Source, Environment.NewLine,
                        item.Message);
                }
                Console.WriteLine("continue job done");
                
            }, TaskContinuationOptions.OnlyOnFaulted);

            tExHandler.Wait();

            Console.WriteLine("主线程即将结束");
            
            
        }


        static event EventHandler<AggregateExceptionArgs> AggregateExceptinCatched;

        public class AggregateExceptionArgs : EventArgs
        {
            public AggregateException AggregateException { get; set; }
        }

        public static void ExByEvent()
        {
            AggregateExceptinCatched += Program_AggregateExceptionCatched;

            Task t = new Task(() =>
            {
                try
                {
                    throw new InvalidOperationException("sdddsddddEX");
                }
                catch(Exception ex)
                {
                    AggregateExceptionArgs exArgs = new AggregateExceptionArgs()
                    {
                        AggregateException = new AggregateException(ex),
                    };
                    AggregateExceptinCatched(null, exArgs);
                }
                
            });

            t.Start();


            Console.WriteLine("ExByEvent end");

        }
        

        static void Program_AggregateExceptionCatched(object sender, AggregateExceptionArgs e)
        {
            foreach (var item in e.AggregateException.InnerExceptions)
            {
                Console.WriteLine("异常类型：{0}{1}，来自：{2}{3}，异常内容：{4}",
                    item.GetType(), Environment.NewLine,
                    item.Source, Environment.NewLine,
                    item.Message);
            }
        }
    }
}
