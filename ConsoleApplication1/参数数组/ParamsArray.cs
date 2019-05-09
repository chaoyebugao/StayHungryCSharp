using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.参数数组
{
    class ParamsArray
    {
        public static void Exec()
        {
            var a1 = new int[] { 3, 5 };
            var a2 = new int[] { 3, 5 };

            Test1(a1, a2);

            Console.WriteLine();

            Test2(new int[] { 3, 5 });
            Test2(3, 5);

            Console.WriteLine();

            Test3(new int[] {3, 5 });
            Test3(3, 5);
            Test3(3, 5, 6);
        }

        //多维数组也是可以的
        private static void Test1(params int[][] array)
        {
            Console.WriteLine("Test1 - array.Length:" + array.Length);
        }

        //会报错，params不参与方法签名
        //private static void Test1(int[][] array) { }

        //会报错，ref、out都不能一起使用
        //private static void Test1(params ref int[] array) { }
        //private static void Test1(params out int[] array) { }

        //params 数组必须是方法的最后一个参数
        //private static void Test1(params int[] array, int a) { }
        //private static void Test1(params int[] array, params int[] a2) { }

        #region 非params方法是优先于一个params方法，直接传递数组对象则根据签名方法优先匹配原则
        private static void Test2(int a1, int a2)
        {
            Console.WriteLine("Test2 - No params method");
        }

        //直接传递数组对象，这里比较优先
        private static void Test2(params int[] array)
        {
            Console.WriteLine("Test2 - params method");
        }
        
        private static void Test3(int a1, params int[] array)
        {
            Console.WriteLine("Test3 - a1 contained");
        }

        //直接传递数组对象，这里比较优先
        private static void Test3(params int[] array)
        {
            Console.WriteLine("Test3 - params only");
        }
        #endregion
    }
}
