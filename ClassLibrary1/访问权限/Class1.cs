using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.访问权限
{
    public class Class1
    {
        public static void Haha()
        {
            Console.WriteLine("You got me!");
        }

        internal static void Haha2()
        {
            Console.WriteLine("You got me!");
        }
    }
}
