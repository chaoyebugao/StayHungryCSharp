using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.构造函数
{
    class 静态和实例构造函数并存
    {
        class Class1
        {
            public static int count;

            static Class1()
            {
                //先被调用，且只有1此
                count++;
            }
            public Class1()
            {
                //两次new，两次被调用
                count++;
            }
        }

        public static void Exec()
        {
            Class1 o1 = new Class1();
            Class1 o2 = new Class1();
            Console.WriteLine(Class1.count);    //3
        }

    }
}
