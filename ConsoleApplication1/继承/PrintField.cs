using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.继承
{
    class A
    {
        public A()
        {
            PrintFields("a con");
        }

        public virtual void PrintFields(string str)
        {
            Console.WriteLine(str);
        }
    }
    class B : A
    {
        int x = 1;
        int y;
        public B()
        {
            base.PrintFields("B in construct");
            y = -1;
        }
        public override void PrintFields(string str)
        {
            Console.WriteLine("x={0},y={1}", x, y);
        }
    }
}
