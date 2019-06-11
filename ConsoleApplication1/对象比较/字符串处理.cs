using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.对象比较
{
    class 字符串处理
    {
        public static void Exec()
        {
            var r1 = "Hello world!";
            var r2 = "Hello";
            var r3 = r2 + " world!";

            Console.WriteLine(r1 == r3);    //确定字符串相同，True
            Console.WriteLine(object.ReferenceEquals(r1, r3));   //False

            r2 = "33";
            Console.WriteLine(r3);  //Hello world!
        }
    }

}
