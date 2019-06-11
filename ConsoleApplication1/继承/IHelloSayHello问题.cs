using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.继承
{
    class IHelloSayHello问题
    {
        public static void Exec()
        {
            MyHello r1 = new MyHello();
            r1.SayHello();  //输出：Base

            IHello r2 = new MyHello();
            r2.SayHello();  //输出：MyHello
        }
    }

    interface IHello
    {
        void SayHello();
    }

    class Base : IHello
    {
        public void SayHello()
        {
            Console.WriteLine("Base");
        }
    }

    class MyHello : Base, IHello
    {
        void IHello.SayHello()
        {
            Console.WriteLine("MyHello");
        }
    }
}
