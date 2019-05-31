using ConsoleApp2.Data.DistributedRepositories;
using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var i = 0;
            var errCount = 0;

            while (i < 1)
            {
                try
                {
                    var repo = new Data.DistributedRepositories._2PC.自实现简单2PC();
                    repo.Register();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    errCount++;
                }
                i++;
            }
            
            Console.WriteLine("执行完毕，错误:{errCount}");
            Console.ReadKey();
        }
    }
}
