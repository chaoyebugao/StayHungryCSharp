using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.抽象工厂
{
    class NanChangFactory : Creator
    {
        public override YaBo CreateYaBo()
        {
            return new NanchangYaBo();
        }

        public override YaJia CreateYaJia()
        {
            return new NanchangYaJia();
        }
    }
}
