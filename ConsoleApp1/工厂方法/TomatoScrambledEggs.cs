using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.工厂方法
{
    class TomatoScrambledEggs : Food
    {
        public override void Make()
        {
            Console.WriteLine("西红柿炒鸡蛋好了");
        }
    }

    class TomatoScrambledEggsFactory : Creator
    {
        public override Food MakeFoodFactory()
        {
            return new TomatoScrambledEggs();
        }
    }
}
