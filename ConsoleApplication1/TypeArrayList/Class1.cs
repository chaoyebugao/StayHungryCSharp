using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.TypeArrayList
{
    class Class1
    {
        public static void Exec()
        {
            ArrayList al = new ArrayList();

            al.Add(1);//发生装箱

            al.Add("2");//发生装箱

            var r1 = al[0];
            Console.WriteLine(r1.GetType());//有拆箱，INT
            var r2 = al[1];
            Console.WriteLine(r2.GetType());//有拆箱，string

        }
    }
}
