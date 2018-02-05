using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.建造者
{
    class ConcreteBuilder1 : Builder
    {
        Computer computer = new Computer();
        public override void BuildPartCPU()
        {
            computer.Install("CPU i7");
        }

        public override void BuildPartMainBoard()
        {
            computer.Install("主板 华硕");
        }

        public override Computer GetComputer()
        {
            return computer;
        }
    }
}
