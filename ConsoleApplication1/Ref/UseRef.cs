using HungryUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Ref
{
    class UseRef
    {
        public static void Exec()
        {
            var p1 = new Person()
            {
                Name = "张三1",
            };

            var p2 = new Person()
            {
                Name = "张三2",
            };

            var p3 = new Person()
            {
                Name = "张三3",
            };

            ChangeName1(p1);
            Console.WriteLine(p1.Name); //cn1

            ChangeName2(ref p2);
            Console.WriteLine(p2.Name); //cn2
        }

        private static void ChangeName1(Person p)
        {
            //即时窗口查看，p与p2的地址是不一样的，说明p是p2的副本，但都使用相同的引用（指向同一个Person）
            p.Name = "cn1";
        }

        private static void ChangeName2(ref Person p)
        {
            //即时窗口查看，p与p2的地址是一样的，说明直接使用了p2
            p.Name = "cn2";
        }

    }


    class Person
    {
        public string Name { get; set; }
    }

}
