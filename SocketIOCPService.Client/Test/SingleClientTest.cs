using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketSAEA.Client.Test
{
    //单客户，Send并发测试
    class SingleClientTest
    {
        public void Exec()
        {
            Thread.Sleep(1000);

            Request.Connect();
            Console.WriteLine("[Client]服务已连接");
                        

            ParallelLoopResult result = Parallel.For(0, 60000, i =>
            {
                Request.Send(@"
sdegsregrykutkry5j4sdegsregrykutkry5j4sdegsregrykutkry5j4sdegsregrykutkry5j4sdegsregrykutkry5j4sdegsregrykutkry5j4sdegsregrykutkry5j4sdegsregrykutkry5j4
");
            });


            while (result.IsCompleted)
            {
                Console.WriteLine(Request.sManager.listArgs.Count);
                break;
            }




        }
        
    }
}
