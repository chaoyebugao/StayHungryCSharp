using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.工厂方法
{

    /// <summary>
    /// 工厂方法模式
    /// 每个Food创建自己的工厂，创建自己的实例
    /// </summary>
    class FoodCreatorFactoryDemo
    {
        public static void Exec()
        {
            // 初始化做菜的两个工厂（）
            var shreddedPorkWithPotatoesFactory = new ShreddedPorkWithPotatoesFactory();
            var tomatoScrambledEggsFactory = new TomatoScrambledEggsFactory();

            // 开始做西红柿炒蛋
            var tomatoScrambleEggs = tomatoScrambledEggsFactory.MakeFoodFactory();
            tomatoScrambleEggs.Make();

            //开始做土豆肉丝
            var shreddedPorkWithPotatoes = shreddedPorkWithPotatoesFactory.MakeFoodFactory();
            shreddedPorkWithPotatoes.Make();
        }
    }
}
