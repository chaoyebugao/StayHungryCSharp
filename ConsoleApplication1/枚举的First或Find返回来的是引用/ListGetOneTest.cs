using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.枚举的First或Find返回来的是引用
{
    class ListGetOneTest
    {
        public static void Exec()
        {
            var list = new List<FindTest>()
            {
                new FindTest()
                {
                     Letter = "a",
                },
                new FindTest()
                {
                     Letter = "b",
                },
                new FindTest()
                {
                     Letter = "c",
                },
            };


            var itemB = list.Where(m => m.Letter == "b").FirstOrDefault();
            itemB.Letter = "2";

            Console.WriteLine(string.Join(",", list.Select(m => m.Letter)));//a,2,b，元素被改变了，说明FirstOrDefault返回的是一个引用，用Find也是一样的结果


            var list2 = new List<string> { "1", "2", "3" };

            var item2 = list2.FirstOrDefault(m => m == "2");
            item2 = "b";

            Console.WriteLine(string.Join(",", list2));//1,2,3，对string无效
            

        }
    }

    class FindTest
    {
        public string Letter { get; set; }
    }
}
