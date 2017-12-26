using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApplication1.排序算法
{
    class 冒泡算法
    {
        //比较临时变量交换和索引交换
        public static void TempVsIndexInArray()
        {
            int count = 100000;

            List<double> execResList1 = new List<double>();
            List<double> execResList2 = new List<double>();

            for (int i = 0; i < count; i++)
            {
                var e1 = 排序算法.冒泡算法.Exec1();
                execResList1.Add(e1);
                var e2 = 排序算法.冒泡算法.Exec2();
                execResList2.Add(e2);
            }

            Console.WriteLine("execResList1 avg:" + execResList1.Average());
            Console.WriteLine("execResList2 avg:" + execResList2.Average());
            //execResList1 avg:0.338343260000001
            //execResList2 avg:0.255845619999997
        }

        public static double Exec1()
        {
            //double[] data = new double[] { 2.5D, 1.3D, 0.5D, 4D, 3.5D, 1.1D, 6D, 5D, 2.1D, 6.5D, 4.7D, 8.3D, 6.8D, 9.3D, 2.53D, 2.5D, 6.4D, 6.4D, 6.2D, 7.3D, 8.7D, 2.5D, 1.3D, 0.5D, 4D, 3.5D, 1.1D, 6D, 5D, 2.1D, 6.5D, 4.7D, 8.3D, 6.8D, 9.3D, 2.53D, 2.5D, 6.4D, 6.4D, 6.2D, 7.3D, 8.7D, 2.5D, 1.3D, 0.5D, 4D, 3.5D, 1.1D, 6D, 5D, 2.1D, 6.5D, 4.7D, 8.3D, 6.8D, 9.3D, 2.53D, 2.5D, 6.4D, 6.4D, 6.2D, 7.3D, 8.7D, 2.5D, 1.3D, 0.5D, 4D, 3.5D, 1.1D, 6D, 5D, 2.1D, 6.5D, 4.7D, 8.3D, 6.8D, 9.3D, 2.53D, 2.5D, 6.4D, 6.4D, 6.2D, 7.3D, 8.7D, 2.5D, 1.3D, 0.5D, 4D, 3.5D, 1.1D, 6D, 5D, 2.1D, 6.5D, 4.7D, 8.3D, 6.8D, 9.3D, 2.53D, 2.5D, 6.4D, 6.4D, 6.2D, 7.3D, 8.7D, 2.5D, 1.3D, 0.5D, 4D, 3.5D, 1.1D, 6D, 5D, 2.1D, 6.5D, 4.7D, 8.3D, 6.8D, 9.3D, 2.53D, 2.5D, 6.4D, 6.4D, 6.2D, 7.3D, 8.7D, 2.5D, 1.3D, 0.5D, 4D, 3.5D, 1.1D, 6D, 5D, 2.1D, 6.5D, 4.7D, 8.3D, 6.8D, 9.3D, 2.53D, 2.5D, 6.4D, 6.4D, 6.2D, 7.3D, 8.7D, 2.5D, 1.3D, 0.5D, 4D, 3.5D, 1.1D, 6D, 5D, 2.1D, 6.5D, 4.7D, 8.3D, 6.8D, 9.3D, 2.53D, 2.5D, 6.4D, 6.4D, 6.2D, 7.3D, 8.7D, 2.5D, 1.3D, 0.5D, 4D, 3.5D, 1.1D, 6D, 5D, 2.1D, 6.5D, 4.7D, 8.3D, 6.8D, 9.3D, 2.53D, 2.5D, 6.4D, 6.4D, 6.2D, 7.3D, 8.7D, 2.5D, 1.3D, 0.5D, 4D, 3.5D, 1.1D, 6D, 5D, 2.1D, 6.5D, 4.7D, 8.3D, 6.8D, 9.3D, 2.53D, 2.5D, 6.4D, 6.4D, 6.2D, 7.3D, 8.7D, 2.5D, 1.3D, 0.5D, 4D, 3.5D, 1.1D, 6D, 5D, 2.1D, 6.5D, 4.7D, 8.3D, 6.8D, 9.3D, 2.53D, 2.5D, 6.4D, 6.4D, 6.2D, 7.3D, 8.7D, 2.5D, 1.3D, 0.5D, 4D, 3.5D, 1.1D, 6D, 5D, 2.1D, 6.5D, 4.7D, 8.3D, 6.8D, 9.3D, 2.53D, 2.5D, 6.4D, 6.4D, 6.2D, 7.3D, 8.7D };
            double[] data = new double[] { 2.5D, 1.3D, 0.5D, 4D, 3.5D, 1.1D, 6D, 5D, 2.1D};
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int i = 0; i < data.Length - 1; i++)
            {
                for (int j = 0; j < data.Length - 1 - i; j++)
                {
                    if (data[j] > data[j + 1])
                    {
                        data[j] = data[j] + data[j + 1];
                        data[j + 1] = data[j] - data[j + 1];
                        data[j] = data[j] - data[j + 1];
                    }
                }
            }
            
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            
            //Console.WriteLine(string.Join(",", data));

            return ts.TotalMilliseconds;
        }

        public static double Exec2()
        {
            //double[] data = new double[] { 2.5D, 1.3D, 0.5D, 4D, 3.5D, 1.1D, 6D, 5D, 2.1D, 6.5D, 4.7D, 8.3D, 6.8D, 9.3D, 2.53D, 2.5D, 6.4D, 6.4D, 6.2D, 7.3D, 8.7D, 2.5D, 1.3D, 0.5D, 4D, 3.5D, 1.1D, 6D, 5D, 2.1D, 6.5D, 4.7D, 8.3D, 6.8D, 9.3D, 2.53D, 2.5D, 6.4D, 6.4D, 6.2D, 7.3D, 8.7D, 2.5D, 1.3D, 0.5D, 4D, 3.5D, 1.1D, 6D, 5D, 2.1D, 6.5D, 4.7D, 8.3D, 6.8D, 9.3D, 2.53D, 2.5D, 6.4D, 6.4D, 6.2D, 7.3D, 8.7D, 2.5D, 1.3D, 0.5D, 4D, 3.5D, 1.1D, 6D, 5D, 2.1D, 6.5D, 4.7D, 8.3D, 6.8D, 9.3D, 2.53D, 2.5D, 6.4D, 6.4D, 6.2D, 7.3D, 8.7D, 2.5D, 1.3D, 0.5D, 4D, 3.5D, 1.1D, 6D, 5D, 2.1D, 6.5D, 4.7D, 8.3D, 6.8D, 9.3D, 2.53D, 2.5D, 6.4D, 6.4D, 6.2D, 7.3D, 8.7D, 2.5D, 1.3D, 0.5D, 4D, 3.5D, 1.1D, 6D, 5D, 2.1D, 6.5D, 4.7D, 8.3D, 6.8D, 9.3D, 2.53D, 2.5D, 6.4D, 6.4D, 6.2D, 7.3D, 8.7D, 2.5D, 1.3D, 0.5D, 4D, 3.5D, 1.1D, 6D, 5D, 2.1D, 6.5D, 4.7D, 8.3D, 6.8D, 9.3D, 2.53D, 2.5D, 6.4D, 6.4D, 6.2D, 7.3D, 8.7D, 2.5D, 1.3D, 0.5D, 4D, 3.5D, 1.1D, 6D, 5D, 2.1D, 6.5D, 4.7D, 8.3D, 6.8D, 9.3D, 2.53D, 2.5D, 6.4D, 6.4D, 6.2D, 7.3D, 8.7D, 2.5D, 1.3D, 0.5D, 4D, 3.5D, 1.1D, 6D, 5D, 2.1D, 6.5D, 4.7D, 8.3D, 6.8D, 9.3D, 2.53D, 2.5D, 6.4D, 6.4D, 6.2D, 7.3D, 8.7D, 2.5D, 1.3D, 0.5D, 4D, 3.5D, 1.1D, 6D, 5D, 2.1D, 6.5D, 4.7D, 8.3D, 6.8D, 9.3D, 2.53D, 2.5D, 6.4D, 6.4D, 6.2D, 7.3D, 8.7D, 2.5D, 1.3D, 0.5D, 4D, 3.5D, 1.1D, 6D, 5D, 2.1D, 6.5D, 4.7D, 8.3D, 6.8D, 9.3D, 2.53D, 2.5D, 6.4D, 6.4D, 6.2D, 7.3D, 8.7D, 2.5D, 1.3D, 0.5D, 4D, 3.5D, 1.1D, 6D, 5D, 2.1D, 6.5D, 4.7D, 8.3D, 6.8D, 9.3D, 2.53D, 2.5D, 6.4D, 6.4D, 6.2D, 7.3D, 8.7D };
            double[] data = new double[] { 2.5D, 1.3D, 0.5D, 4D, 3.5D, 1.1D, 6D, 5D, 2.1D };
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int i = 0; i < data.Length - 1; i++)
            {
                for (int j = 0; j < data.Length - 1 - i; j++)
                {
                    if (data[j] > data[j + 1])
                    {
                        var temp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = temp;
                    }
                }
            }

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            
           // Console.WriteLine(string.Join(",", data));

            return ts.TotalMilliseconds;
        }


    }
}
