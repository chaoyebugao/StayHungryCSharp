using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.继承
{
    public class PrintField
    {
        public static void Exec()
        {
            var r1 = new B();
            r1.PrintFields("r1");

        }
    }

    class A
    {
        public A()
        {
            //r1 - 1
            PrintFields("A ctor");  //r1 - 2，此时PrintFields已被重写
        }

        public virtual void PrintFields(string str)
        {
            //r1 - 6，被用base调用
            Console.WriteLine(str);
        }
    }
    class B : A
    {
        int x = 1;
        int y = 0;
        public B()
        {
            //r1 - 4
            base.PrintFields("B ctor"); //r1 - 5
            y = -1;
        }

        public override void PrintFields(string str)
        {
            //r1 - 3
            //r1 - 7
            Console.WriteLine("x={0},y={1}", x, y);
        }
    }
}
