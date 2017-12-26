using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Byte和Int运算
{
    class ByteAndInt
    {
        public static void Exec()
        {
            byte b1 = 100;

            dynamic r1 = b1;
            Console.WriteLine(r1.GetType());//System.Byte
            r1 = r1 + 100;
            Console.WriteLine(r1.GetType());//System.Int32

            byte r2 = 100;
            object r3 = r2;
            Console.WriteLine(r3.GetType());//System.Byte
        }
    }
}
