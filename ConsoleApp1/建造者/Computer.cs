using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.建造者
{
    class Computer
    {
        private IList<string> components = new List<string>();

        /// <summary>
        /// 安装
        /// </summary>
        /// <param name="component">The component.</param>
        public void Install(string component)
        {
            components.Add(component);
        }

        public void Show()
        {
            Console.WriteLine("电脑组装好了，组件如下：");
            foreach(var item in components)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}
