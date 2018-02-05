using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.简单工厂
{
    class TomatoScrambledEggs : Food
    {
        public override void Make()
        {
            Console.WriteLine("一份西红柿炒蛋");
        }
    }
}
