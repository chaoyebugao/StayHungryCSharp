using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.装箱拆箱
{
    class BoxUnbox
    {
        public static void Exec()
        {
            int i1 = 100;
            object o1 = i1;

            i1++;
            
            int i2 = (int)o1;
            i2 = i2 + 5;

            Console.WriteLine(i1);//101
            Console.WriteLine(o1);//100
            Console.WriteLine(i2);//105
            Console.WriteLine(o1);//100
        }
    }
}
