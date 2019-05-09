using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.工厂方法
{
    class ShreddedPorkWithPotatoes : Food
    {
        public override void Make()
        {
            Console.WriteLine("土豆肉丝好了");
        }
    }

    class ShreddedPorkWithPotatoesFactory : Creator
    {
        public override Food MakeFoodFactory()
        {
            return new ShreddedPorkWithPotatoes();
        }
    }
}
