using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.单例
{
    sealed class Singleton
    {
        static Singleton instance = null;
        private static readonly object syncRoot = new object();

        //防止被new实例
        private Singleton()
        {

        }

        public static Singleton Instance
        {
            get
            {
                return instance == null ? new Singleton() : instance;
            }
        }

        /// <summary>
        /// 商双锁定
        /// </summary>
        public static Singleton ThreadSafeInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if(instance == null)
                        {
                            instance = new Singleton();
                        }
                    }
                }

                return instance;
            }
        }
    }
}
