using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.实例中的static
{
    class StaticObjOfInstance
    {
        public static void Exec()
        {
            SooI s1 = new SooI();
            Console.WriteLine(s1.Ns);   //2
            Console.WriteLine(SooI.S1); //3

            SooI.S1 = SooI.S1 + 100;

            SooI s2 = new SooI();
            Console.WriteLine(SooI.S1); //103
        }
    }

    class SooI
    {
        public static int S1 = 3;
        public int Ns = 2;
    }
    
}
