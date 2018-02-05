using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.抽象工厂
{
    class ShanghaiFactory : Creator
    {
        public override YaBo CreateYaBo()
        {
            return new ShanghaiYaBo();
        }

        public override YaJia CreateYaJia()
        {
            return new ShanghaiYaJia();
        }
    }
}
