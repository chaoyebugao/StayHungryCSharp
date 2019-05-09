using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.建造者
{
    /// <summary>
    /// 工头
    /// </summary>
    class Director
    {
        /// <summary>
        /// 指挥建造
        /// </summary>
        /// <param name="builder">具体建筑工人</param>
        /// <returns></returns>
        public Computer Construct(Builder builder)
        {
            builder.BuildPartCPU();
            builder.BuildPartMainBoard();

            return builder.GetComputer();
        }
    }
}
