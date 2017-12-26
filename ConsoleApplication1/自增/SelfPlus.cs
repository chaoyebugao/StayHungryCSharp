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
            var i2 = 5;
            Console.WriteLine("i1:"+ (++i1));
            Console.WriteLine("i2:" + (i2++));
        }
    }
}
