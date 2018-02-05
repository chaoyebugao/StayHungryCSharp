using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.适配器
{
    /// <summary>
    /// 三个孔的插头，也就是适配器模式中的目标角色
    /// </summary>
    public class TwoHole
    {
        public void TwoInstall()
        {
            Console.WriteLine("我是两个孔的插头");
        }
    }
}
