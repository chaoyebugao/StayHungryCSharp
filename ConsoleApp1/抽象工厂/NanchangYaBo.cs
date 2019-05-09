using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.抽象工厂
{
    class NanchangYaBo : YaBo
    {
        public override void Make()
        {
            Console.WriteLine("南昌的鸭脖制作完成了");
        }
    }
}
