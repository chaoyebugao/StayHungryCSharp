using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.字符串长度
{
    public class 字符串长度计算
    {
        public static void Exec()
        {
            
            string num = "1";
            int i = num.Length;//1
            Console.WriteLine($"{num}, Len:{i}");
            int i0 = System.Text.Encoding.Default.GetBytes(num).Length;//gb2312
            Console.WriteLine($"Default:{i0}");  //1
            int i1 = System.Text.Encoding.UTF8.GetBytes(num).Length;
            Console.WriteLine($"UTF8:{i1}");    //1
            int i2 = System.Text.Encoding.ASCII.GetBytes(num).Length;
            Console.WriteLine($"ASCII:{i2}");    //1
            int i3 = System.Text.Encoding.GetEncoding("gb2312").GetBytes(num).Length;
            Console.WriteLine($"gb2312:{i3}");   //1
            int i4 = System.Text.Encoding.GetEncoding("gbk").GetBytes(num).Length;
            Console.WriteLine($"gbk:{i4}");  //1

            Console.WriteLine();


            string c = "abc";
            int j = c.Length;//3
            Console.WriteLine($"{c}, Len:{j}");
            int j0 = System.Text.Encoding.Default.GetBytes(c).Length;//gb2312
            Console.WriteLine($"Default:{j0}"); //3
            int j1 = System.Text.Encoding.UTF8.GetBytes(c).Length;
            Console.WriteLine($"UTF8:{j1}");    //3
            int j2 = System.Text.Encoding.ASCII.GetBytes(c).Length;
            Console.WriteLine($"ASCII:{j2}");   //3
            int j3 = System.Text.Encoding.GetEncoding("gb2312").GetBytes(c).Length;
            Console.WriteLine($"gb2312:{j3}");  //3
            int j4 = System.Text.Encoding.GetEncoding("gbk").GetBytes(c).Length;
            Console.WriteLine($"gbk:{j4}"); //3


            Console.WriteLine();

            string cn = "车";
            int k = cn.Length;//1
            Console.WriteLine($"{cn}, Len:{k}");
            int k0 = System.Text.Encoding.Default.GetBytes(cn).Length;//gb2312
            Console.WriteLine($"Default:{k0}"); //2
            int k1 = System.Text.Encoding.UTF8.GetBytes(cn).Length;
            Console.WriteLine($"UTF8:{k1}");    //3
            int k12 = System.Text.Encoding.Unicode.GetBytes(cn).Length;
            Console.WriteLine($"Unicode:{k12}");    //2
            int k13 = System.Text.Encoding.UTF32.GetBytes(cn).Length;
            Console.WriteLine($"UTF32:{k13}");  //4
            int k2 = System.Text.Encoding.ASCII.GetBytes(cn).Length;
            Console.WriteLine($"ASCII:{k2}");   //1
            int k3 = System.Text.Encoding.GetEncoding("gb2312").GetBytes(cn).Length;
            Console.WriteLine($"gb2312:{k3}");  //2
            int k4 = System.Text.Encoding.GetEncoding("gbk").GetBytes(cn).Length;
            Console.WriteLine($"gbk:{k4}"); //2
        }
    }
}
