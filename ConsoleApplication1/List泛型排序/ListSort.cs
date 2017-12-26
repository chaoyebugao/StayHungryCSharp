using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.List泛型排序
{
    class ListSort
    {
        public static void Exec()
        {
            var list = new List<int>() { 32, 55, 43, 56, 34, 66 };

            var col = new Collection<int>(list);

            list.Add(99);

            Console.WriteLine(list.GetHashCode());//46104728
            Console.WriteLine(String.Join(",", col));//32,55,43,56,34,66,99
            list.Sort();
            Console.WriteLine(list.GetHashCode());//46104728
            Console.WriteLine(String.Join(",", col));//32,34,43,55,56,66,99
        }
    }
}
