using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.适配器
{
    /// <summary>
    /// 适配器模式
    /// 新环境中不需要去重复实现已经存在了的实现而很好地把现有对象（指原来环境中的现有对象）加入到新环境来使用
    /// </summary>
    class SocketAdapterDemo
    {
        public static void Exec()
        {
            // 现在客户端可以通过电适配要使用2个孔的插头了
            IThreeHole threehole = new PowerAdapter();
            threehole.StandardInstall();
            Console.ReadLine();
        }
    }
}
