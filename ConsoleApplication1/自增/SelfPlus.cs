using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.自增
{
    class SelfPlus
    {
        public static void Exec()
        {
            var i1 = 5;
            Console.WriteLine($"{++i1}");   //6，先计算i1 + 1，再返回

            var i2 = 5;
            Console.WriteLine($"{i2++}");  //5，先返回返回i2，再计算i2 + 1
        }
    }
}
