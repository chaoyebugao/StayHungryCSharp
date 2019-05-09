using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.继承
{
    class New和Override不同
    {
        public static void Exec()
        {
            Class2 r1 = new Class2();
            r1.MethodA();    //BaseClass.MethodA
            r1.MethodB();    //Class1.MethodB

            Console.WriteLine();

            //new和override不同点：override会覆盖掉父类的，new只是子类在自身范围内隐藏而已（new与父类无关）
            BaseClass r2 = new Class2();
            r2.MethodB();   //BaseClass.MethodC
            r2.MethodC();   //Class1.MethodC
            r2.MethodD();   //Class2.MethodD

            //new和override都可以调用base
            Console.WriteLine();
            var r3 = new Class2();
            r3.MethodE();
            //Class2-Class1-BaseClass
            //BaseClass.MethodE
        }
    }

    abstract class BaseClass
    {
        public virtual void MethodA()
        {
            Console.WriteLine("BaseClass.MethodA");
        }

        public virtual void MethodB()
        {
            Console.WriteLine("BaseClass.MethodB");
        }

        public virtual void MethodC()
        {
            Console.WriteLine("BaseClass.MethodC");
        }

        public virtual void MethodD()
        {
            Console.WriteLine("BaseClass.MethodD");
        }

        public virtual void MethodE()
        {
            Console.WriteLine("BaseClass");
            Console.WriteLine("BaseClass.MethodE");
        }
    }

    class Class1 : BaseClass
    {
        public void MethodA(string r1)
        {
            Console.WriteLine("Class1.MethodA");
        }

        public new void MethodB()
        {
            Console.WriteLine("Class1.MethodB");
        }

        public override void MethodC()
        {
            Console.WriteLine("Class1.MethodC");
        }

        public override void MethodD()
        {
            Console.WriteLine("Class1.MethodD");
        }

        public new virtual void MethodE()
        {
            Console.Write("Class1-");
            base.MethodE();
        }
    }

    class Class2 : Class1
    {
        public new void MethodC()
        {
            //隐藏父类的而已
            Console.WriteLine("Class2.MethodC");
        }

        public override void MethodD()
        {
            //这是直接把父类的都改写了
            Console.WriteLine("Class2.MethodD");
        }

        public override void MethodE()
        {
            Console.Write("Class2-");
            base.MethodE();
        }
    }


}
