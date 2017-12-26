using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Str作为参数被处理后
{
    class StrAsParam
    {
        delegate void Haha(ref string a);

        public static void Exec()
        {
            string str = "Welcome to earth";

            GetSubStr(str);
            Console.WriteLine(str);//Welcome to earth

            GetSubStrWithRef(ref str);
            Console.WriteLine(str);//Welcome

            str = "Welcome to earth";
            Haha h1 = new Haha(GetSubStrWithRef);

            h1(ref str);
            Console.WriteLine(str);//Welcome
        }

        public static void GetSubStr(string a)
        {
            a = a.Substring(0, a.Length - 9);
        }

        public static void GetSubStrWithRef(ref string a)
        {
            a = a.Substring(0, a.Length - 9);
        }
    }
}
