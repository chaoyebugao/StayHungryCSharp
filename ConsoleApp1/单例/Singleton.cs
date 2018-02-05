using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.单例
{

    /// <summary>
    /// 单例模式
    /// 确保一个类只有一个实例,并提供一个全局访问点
    /// </summary>
    public class Singleton
    {
        private static Singleton uniqueInstance;

        private static readonly object syncObj = new object();

        /// <summary>
        /// 私有掉构造方法，使<see cref="Singleton"/>类不能被外部创建
        /// </summary>
        private Singleton()
        {

        }


        /// <summary>
        /// 定义外部访问点来提供单例
        /// </summary>
        /// <returns></returns>
        public static Singleton GetSingleton()
        {
            if (uniqueInstance == null)
            {
                //双重锁定，外部的锁定是为了避免每次都lock，if可以避免这样不必要的性能损失
                lock (syncObj)
                {
                    if(uniqueInstance == null)
                    {
                        uniqueInstance = new Singleton();
                    }
                }
            }

            return uniqueInstance;
        }
    }
}
