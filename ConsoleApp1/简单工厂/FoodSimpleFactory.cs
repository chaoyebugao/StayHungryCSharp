using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.简单工厂
{
    /// <summary>
    /// 简单工厂模式
    /// 负责生产对象的一个类
    /// </summary>
    class FoodSimpleFactory
    {
        public static Food Make(string foodName)
        {
            Food food = null;
            if (foodName.Equals("西红柿炒蛋"))
            {
                food = new TomatoScrambledEggs();
            }
            else if (foodName.Equals("土豆肉丝"))
            {
                food = new ShreddedPorkWithPotatoes();
            }

            return food;
        }
    }
}
