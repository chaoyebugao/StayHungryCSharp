using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.对象比较
{
    class ObjEquation
    {
        /// <summary>
        /// 文章介绍链接：http://www.cnblogs.com/huangsheng/p/6490578.html
        /// </summary>
        public static void Exec()
        {
            //IntEq();
            //ObjEq();
            //IntAssignmentEq();
            ObjValEq();
            //StrEq();
            //RefEq();
            //RefAssignmentEq();
            //AnoEq();
        }

        public static void IntEq()
        {
            int m1 = 2;
            int m2 = 2;

            Console.WriteLine(m1 == m2);//值比较True
            Console.WriteLine(m1.Equals(m2));//值比较True
            Console.WriteLine(System.Object.ReferenceEquals(m1, m2));//引用False
        }

        public static void ObjEq()
        {
            object m1 = 2;
            object m2 = 2;

            Console.WriteLine(m1 == m2);//引用类型引用比较False
            Console.WriteLine(m1.Equals(m2));//Object虚方法值比较True
            Console.WriteLine(System.Object.ReferenceEquals(m1, m2));//引用False
        }

        public static void IntAssignmentEq()
        {
            int m1 = 3434;
            int m2 = m1;

            Console.WriteLine(m1 == m2);//值比较True
            Console.WriteLine(m1.Equals(m2));//值比较True
            Console.WriteLine(System.Object.ReferenceEquals(m1, m2));//引用比较False
        }

        public static void ObjValEq()
        {
            object m1 = 2;
            int m2 = 2;

            Console.WriteLine(m1.Equals(m2));//Object虚方法值比较True
            Console.WriteLine(m2.Equals(m1));//Object虚方法值比较True
            Console.WriteLine(System.Object.ReferenceEquals(m1, m2));//引用False
        }

        public static void StrEq()
        {
            string m1 = "tg903eiotf38";
            string m2 = "tg903eiotf38";

            Console.WriteLine(m1 == m2);//字符串值比较True
            Console.WriteLine(m1.Equals(m2));//字符串值比较True
            Console.WriteLine(System.Object.ReferenceEquals(m1, m2));//字符串引用优化比较True
        }

        public class Student
        {
            public long Id { get; set; }

            public string Name { get; set; }
        }

        public static void RefEq()
        {
            Student m1 = new Student()
            {
                Id = 34,
                Name = "朝野布告",
            };
            Student m2 = new Student()
            {
                Id = 34,
                Name = "朝野布告",
            };

            Console.WriteLine(m1 == m2);//False
            Console.WriteLine(m1.Equals(m2));//False
            Console.WriteLine(System.Object.ReferenceEquals(m1, m2));//False
        }

        public static void RefAssignmentEq()
        {
            Student m1 = new Student()
            {
                Id = 34,
                Name = "朝野布告",
            };
            Student m2 = m1;

            m1.Name = "飓风";

            Console.WriteLine(m1.GetHashCode());//46104728
            Console.WriteLine(m2.GetHashCode());//46104728

            Console.WriteLine(m1 == m2);//True
            Console.WriteLine(m1.Equals(m2));//True
            Console.WriteLine(System.Object.ReferenceEquals(m1, m2));//True
            Console.WriteLine(m1.Name);//飓风
            Console.WriteLine(m2.Name);//飓风
        }

        public static void AnoEq()
        {
            var m1 = new { Id = 34, Name = "朝野布告" };
            var m2 = new { Id = 34, Name = "朝野布告" };

            Console.WriteLine(m1 == m2);//False
            Console.WriteLine(m1.GetHashCode());//32076894
            Console.WriteLine(m2.GetHashCode());//32076894
            Console.WriteLine(m1.Equals(m2));//True //这个运行时有优化，会比较内部成员是否一致，一致则True
            Console.WriteLine(System.Object.ReferenceEquals(m1, m2));//False
        }
    }
}
