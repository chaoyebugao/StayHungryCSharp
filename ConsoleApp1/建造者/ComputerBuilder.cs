using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.建造者
{
    /// <summary>
    /// 建造者模式
    /// 创建一个复杂对象，并且这个复杂对象由其各部分子对象通过一定的步骤组合而成
    /// </summary>
    class ComputerBuilder
    {
        public static void Exec()
        {
            var director = new Director();
            var b1 = new ConcreteBuilder1();

            var computer = director.Construct(b1);

            computer.Show();
        }
    }
}
