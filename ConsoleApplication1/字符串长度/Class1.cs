using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.字符串长度
{
    class Class1
    {
        public static void Exec()
        {
            
            string num = "1";
            int i0 = System.Text.Encoding.Default.GetBytes(num).Length;//gb2312,13
            int i1 = System.Text.Encoding.UTF8.GetBytes(num).Length;//16
            int i2 = System.Text.Encoding.ASCII.GetBytes(num).Length;//10
            int i3 = System.Text.Encoding.GetEncoding("gb2312").GetBytes(num).Length;//13
            int i4 = System.Text.Encoding.GetEncoding("gbk").GetBytes(num).Length;//13
            int i= num.Length;//1

            Console.WriteLine(i0);
            Console.WriteLine(i1);
            Console.WriteLine(i2);
            Console.WriteLine(i3);
            Console.WriteLine(i4);
            Console.WriteLine(i);

            Console.WriteLine();


            string c = "abc";
            int j0 = System.Text.Encoding.Default.GetBytes(c).Length;//gb2312,13
            int j1 = System.Text.Encoding.UTF8.GetBytes(c).Length;//16
            int j2 = System.Text.Encoding.ASCII.GetBytes(c).Length;//10
            int j3 = System.Text.Encoding.GetEncoding("gb2312").GetBytes(c).Length;//13
            int j4 = System.Text.Encoding.GetEncoding("gbk").GetBytes(c).Length;//13
            int j = c.Length;//3

            Console.WriteLine(j0);
            Console.WriteLine(j1);
            Console.WriteLine(j2);
            Console.WriteLine(j3);
            Console.WriteLine(j4);
            Console.WriteLine(j);

            Console.WriteLine();

            string cn = "车";
            int k0 = System.Text.Encoding.Default.GetBytes(cn).Length;//gb2312, 2
            int k1 = System.Text.Encoding.UTF8.GetBytes(cn).Length;//3
            int k12 = System.Text.Encoding.Unicode.GetBytes(cn).Length;//2
            int k13 = System.Text.Encoding.UTF32.GetBytes(cn).Length;//4
            int k2 = System.Text.Encoding.ASCII.GetBytes(cn).Length;//1
            int k3 = System.Text.Encoding.GetEncoding("gb2312").GetBytes(cn).Length;//2
            int k4 = System.Text.Encoding.GetEncoding("gbk").GetBytes(cn).Length;//2
            int k = cn.Length;//1

            Console.WriteLine(k0);
            Console.WriteLine(k1);
            Console.WriteLine(k12);
            Console.WriteLine(k13);
            Console.WriteLine(k2);
            Console.WriteLine(k3);
            Console.WriteLine(k4);
            Console.WriteLine(k);
        }
    }
}
