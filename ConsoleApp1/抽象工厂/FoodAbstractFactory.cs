using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.抽象工厂
{
    /// <summary>
    /// 抽象工厂模式
    /// 抽象工厂提供创建一系列产品的接口
    /// </summary>
    class FoodAbstractFactory
    {
        public static void Exec()
        {
            // 南昌工厂制作南昌的鸭脖和鸭架
            Creator nanChangFactory = new NanChangFactory();
            YaBo nanChangYabo = nanChangFactory.CreateYaBo();
            nanChangYabo.Make();
            YaJia nanChangYajia = nanChangFactory.CreateYaJia();
            nanChangYajia.Make();

            // 上海工厂制作上海的鸭脖和鸭架
            Creator shangHaiFactory = new ShanghaiFactory();
            shangHaiFactory.CreateYaBo().Make();
            shangHaiFactory.CreateYaJia().Make();
        }
    }
}
