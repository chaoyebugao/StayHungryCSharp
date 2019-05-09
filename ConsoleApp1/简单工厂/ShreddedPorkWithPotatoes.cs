using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.简单工厂
{
    class ShreddedPorkWithPotatoes : Food
    {
        public override void Make()
        {
            Console.WriteLine("土豆肉丝");
        }
    }
}
