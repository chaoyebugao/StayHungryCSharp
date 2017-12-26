using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndThreading.IAsyncResult接口
{
    public class AsyncDemo
    {
        //委托
        private delegate string RunDelegate();
        //委托实例
        private RunDelegate _runDelegate;

        private string _name;

        public AsyncDemo(string name)
        {
            _name = name;
            _runDelegate = new RunDelegate(Run);
        }

        public string Run()
        {
            Console.WriteLine("【3】Delegate method excuting");
            return "AsyncDemo: My name is " + _name;
        }

        //开始异步运行
        public IAsyncResult BeginRun(AsyncCallback asyncCallBack, object stateObject)
        {
            Console.WriteLine("【1】BeginRun excuting");
            //_runDelegate.BeginInvoke(asyncCallBack, stateObject);
            for (var i = 1; i < 3; i++)
            {
                Console.WriteLine("Runing...");
                Thread.Sleep(1000);
            }

            return _runDelegate.BeginInvoke(asyncCallBack, stateObject); ;
        }

        /// <summary>
        /// 求结果
        /// </summary>
        /// <param name="ar"></param>
        /// <returns></returns>
        public string EndRun(IAsyncResult ar)
        {
            if (ar == null)
            {
                throw new NullReferenceException("Arggument ar can't be null");
            }

            Console.WriteLine("【2】EndRun excuting");

            return _runDelegate.EndInvoke(ar);
        }

        public static void Exec()
        {
            var demo = new AsyncDemo("chaoyebugao");
            var asyncCallBack = new AsyncCallback(demo.ExeCallback);
            var ar = demo.BeginRun(asyncCallBack, DateTime.Now);
            string demoName = "not run";
            demoName = demo.EndRun(ar);
            Console.WriteLine("【4】EndRun Result reurned");
            Console.WriteLine(demoName);

            Console.Read();
        }

        public void ExeCallback(IAsyncResult ar)
        {
            var stateTime = (DateTime)ar.AsyncState;
            var ts = DateTime.Now - stateTime;
            var tsStr = $"{ts.Hours}小时{ts.Minutes}分{ts.Seconds}秒{ts.Milliseconds}毫秒";
            Console.WriteLine("ExeCallback executed: time eclaps:" + tsStr);
            Console.WriteLine("【5】AsyncCallback extuted");
        }
    }
}
