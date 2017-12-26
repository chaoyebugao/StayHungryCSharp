using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.单例双锁定
{
    //双锁定单例以实现线程安全
    public sealed class DbLckSingleton
    {
        static DbLckSingleton instance = null;
        static readonly object padlock = new object();

        private DbLckSingleton()
        {

        }

        public static DbLckSingleton Instance
        {
            get
            {
                if(instance == null)
                {
                    lock (padlock)
                    {
                        if(instance == null)
                        {
                            instance = new DbLckSingleton();
                        }
                    }
                }

                return instance;
            }
        }
    }
}
