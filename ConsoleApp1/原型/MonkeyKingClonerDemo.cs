using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.原型
{
    /// <summary>
    /// 原型模式
    /// 从已有实例拷贝（如ICloneable接口实现）
    /// </summary>
    class MonkeyKingClonerDemo
    {
        public static void Exec()
        {
            var monkey = new MonkeyConcreteType("真身");

            var monkey2 = monkey.Clone();
        }
    }
}
