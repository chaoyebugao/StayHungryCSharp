using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.整数交换
{
    class IntExt
    {
        public static void Exec()
        {
            Method1();
        }

        public static void Method1()
        {
            int a = 5;
            int b = 10;
            a = a ^ b;
            Console.WriteLine("{0}  {1}", a, b);
            b = b ^ a;
            Console.WriteLine("{0}  {1}", a, b);
            a = a ^ b;
            Console.WriteLine("{0}  {1}", a, b);
            
        }
    }
}
