using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.堆栈
{
    class StackHeap
    {
        public static void Exec()
        {

            double i = 3.5D;
            object obj = i;
            Console.WriteLine("ref hash, i:{0}, obj:{1}", i.GetHashCode(), obj.GetHashCode());
            //输出：ref hash, i:1074528256, obj:1074528256
            Console.WriteLine("value, i:{0}, obj:{1}", i, obj);
            //输出：value, i:3.5, obj:3.5
            Console.WriteLine(System.Object.ReferenceEquals(i, obj));
            //输出：false

            obj = 5.5D;
            Console.WriteLine("ref hash, i:{0}, obj:{1}", i.GetHashCode(), obj.GetHashCode());
            //输出：ref hash, i:1074528256, obj:1075183616
            Console.WriteLine("value, i:{0}, obj:{1}", i, obj);
            //输出：value, i:3.5, obj:5.5


        }

        public static void Exec2()
        {
            int m1 = 3434;
            int m2 = m1;

            //m2 = 3000;

            Console.WriteLine("ref hash, m1:{0}, m2:{1}", m1.GetHashCode(), m2.GetHashCode());
            //输出：ref hash, i:3434, obj:3434
        }

        public static void Exec3()
        {
            Loky l1 = new Loky() { Lol = "fdf1" };

            Loky l2 = l1;

            l2.Lol = "sdas";

            Console.WriteLine("ref hash, l1:{0}, l2:{1}", l1.GetHashCode(), l1.GetHashCode());
            //输出：ref hash, l1:46104728, l2:46104728
        }

        class Loky
        {
            public string Lol { get; set; }
        }
    }
}
