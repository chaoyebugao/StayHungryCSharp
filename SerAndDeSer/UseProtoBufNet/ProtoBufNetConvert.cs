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
            var req = new NetRequest()
            {
                Action = "GetUserInfo",
                ConnUser = new ConnectUser()
                {
                    AuthToken = "testxjxjxjxj",
                    Id = 1548778,
                },
            };
            req.Params = new Dictionary<string, string>
            {
                { "Gavatar", "头像ID" },
            };

            var reqArray = Serialize<NetRequest>(req);
            Console.WriteLine($"reqArray.Length:{reqArray.Length}");
            Console.WriteLine(string.Join(",", reqArray));
            Console.WriteLine();
            var mDes = DeSerialize<NetRequest>(reqArray);
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static byte[] Serialize<T>(T t)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Serializer.Serialize<T>(ms, t);
                return ms.ToArray();
            }
        }

        /// <summary>  
        /// 序列化为文本
        /// </summary>  
        /// <typeparam name="T"></typeparam>  
        /// <param name="t"></param>  
        /// <returns></returns>  
        public static string SerializeToJson<T>(T t)
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

        /// <summary>  
        /// 反序列化  
        /// </summary>  
        /// <typeparam name="T"></typeparam>  
        /// <param name="content"></param>  
        /// <returns></returns>  
        public static T DeSerialize<T>(byte[] content)
        {
            using (MemoryStream ms = new MemoryStream(content))
            {
                T t = Serializer.Deserialize<T>(ms);
                return t;
            }
        }
    }
}
