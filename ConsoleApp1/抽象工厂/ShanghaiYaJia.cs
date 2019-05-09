using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.抽象工厂
{
    class ShanghaiYaJia : YaJia
    {
        public override void Make()
        {
            Console.WriteLine("上海的鸭架制作完成了");
        }
    }
}
