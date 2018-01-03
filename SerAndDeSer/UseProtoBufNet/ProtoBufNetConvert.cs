using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerAndDeSer.UseProtoBufNet
{
    class ProtoBufNetConvert
    {
        public static void Exec()
        {
            var m = new NetModel()
            {
                D1 = DateTime.Parse("2018-1-3 14:11:17"),
                Desc = "测试测试ProtoBufNet",
                RR = 1325,
            };

            var mStr = Serialize<NetModel>(m);
            Console.WriteLine(mStr);
            Console.WriteLine();
            var mDes = DeSerialize<NetModel>(mStr);
        }

        /// <summary>  
        /// 序列化  
        /// </summary>  
        /// <typeparam name="T"></typeparam>  
        /// <param name="t"></param>  
        /// <returns></returns>  
        public static string Serialize<T>(T t)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Serializer.Serialize<T>(ms, t);
                return Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        /// <summary>  
        /// 反序列化  
        /// </summary>  
        /// <typeparam name="T"></typeparam>  
        /// <param name="content"></param>  
        /// <returns></returns>  
        public static T DeSerialize<T>(string content)
        {
            using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(content)))
            {
                T t = Serializer.Deserialize<T>(ms);
                return t;
            }
        }
    }
}
