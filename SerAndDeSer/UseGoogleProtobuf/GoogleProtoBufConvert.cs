using Google.Protobuf;
using Google.Protobuf.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SerAndDeSer.UseGoogleProtobuf
{
    class GoogleProtoBufConvert
    {
        public static void Exec()
        {
            Process p = new Process();
            //设定程序名 
            p.StartInfo.FileName = @"D:\Learning\StayHungry\packages\Google.Protobuf.Tools.3.5.1\tools\windows_x64\protoc";
            var dstpath = @"D:\Learning\StayHungry\SerAndDeSer\UseGoogleProtobuf";
            var srcPath = @"D:\Learning\StayHungry\SerAndDeSer\UseGoogleProtobuf\proto";
            //注意，protoc不允许路径包含中文
            p.StartInfo.Arguments = $@" -IPATH={srcPath} --csharp_out={dstpath} {srcPath}\NetModel.proto";

            //关闭Shell的使用
            p.StartInfo.UseShellExecute = false;
            //重定向标准输入
            p.StartInfo.RedirectStandardInput = true;
            //重定向标准输出
            p.StartInfo.RedirectStandardOutput = true;
            //重定向错误输出
            p.StartInfo.RedirectStandardError = true;
            //设置不显示窗口
            p.StartInfo.CreateNoWindow = true;

            p.Start();

            p.StandardInput.WriteLine("exit");

            string strRst = p.StandardOutput.ReadToEnd();

            Console.WriteLine(strRst);

            var req = new NetRequest()
            {
                Action = "GetUserInfo",
                ConnUser = new ConnectUser()
                {
                    AuthToken = "testxjxjxjxj",
                    Id = 1548778,
                },
            };
            req.Params.Add("Gavatar", "头像ID");

            var reqSize = req.CalculateSize();
            //序列化为字节数组
            var reqByteArray = req.ToByteArray();
            var reqNewtonJson = Newtonsoft.Json.JsonConvert.SerializeObject(req);
            //序列化为JSON文本（尺寸大）
            var reqProtobufJson = JsonFormatter.Default.Format(req);
            Console.WriteLine($"reqSize:{reqSize}");
            //Console.WriteLine($"reqByteArray:{Encoding.UTF8.GetString(reqByteArray)}");
            //Console.WriteLine($"reqNewtonJson:{reqNewtonJson}, reqNewtonJson Length:{reqNewtonJson.Length}");
            //Console.WriteLine($"reqProtobufJson:{reqProtobufJson}, reqProtobufJson Length:{reqProtobufJson.Length}");
            Console.WriteLine();

            //Console.WriteLine(string.Join(",", reqByteArray));

            //反序列化
            var req2 = NetRequest.Parser.ParseFrom(reqByteArray);
            //req2.Params.Add("RealName", "朝野布告");
            var req2Size = req2.CalculateSize();
            var req2ProtobufJson = JsonFormatter.Default.Format(req2);
            Console.WriteLine($"req2Size:{req2Size}");
            req2.ConnUser.Id = 10000000000000000;
            req2Size = req2.CalculateSize();
            Console.WriteLine($"req2Size, 修改某整型数据后:{req2Size}");
            //Console.WriteLine($"req2ProtobufJson:{req2ProtobufJson}, req2ProtobufJson Length:{req2ProtobufJson.Length}");

            Console.WriteLine();

            var pbTest1 = new PbTest1()
            {
                MyBool = true,
                MyBytes = ByteString.CopyFromUtf8("朝野布告"),
                MyDouble = 22.35D,
                MyFloat = 33.6F,
                MyInt32 = 565,
                MyString = "你好啊",
                MyUint32 = 45,
                MyUint64 = 44745845454,
            };
            pbTest1.MyStringList.AddRange(new List<string>()
            {
                "list1",
                "listb",
            });

            var pbTest1ByteArray = pbTest1.ToByteArray();
            Console.WriteLine($"pbTest1 Size:{pbTest1.CalculateSize()}");

            var pbTest2 = UseProtoBufNet.ProtoBufNetConvert.DeSerialize<UseProtoBufNet.PbTest2>(pbTest1ByteArray);

            Console.WriteLine($"pbTest2 Size:{UseProtoBufNet.ProtoBufNetConvert.Serialize<UseProtoBufNet.PbTest2>(pbTest2).Length}");
            Console.WriteLine($"pbTest2 BinaryFormatter Size:{ObjToArraySize(pbTest2)}");
            Console.WriteLine($"pbTest2.MyBytes:{Encoding.UTF8.GetString(pbTest2.MyBytes)}");
            Console.WriteLine($"pbTest2.MyStringList:{string.Join(",", pbTest2.MyStringList)}");

            var pbTest2ByteArray = UseProtoBufNet.ProtoBufNetConvert.Serialize<UseProtoBufNet.PbTest2>(pbTest2);
            var pbTest11 = PbTest1.Parser.ParseFrom(pbTest2ByteArray);

            Console.WriteLine($"pbTest1ByteArray:{string.Join(",", pbTest1ByteArray)}");
            Console.WriteLine($"pbTest2ByteArray:{string.Join(",", pbTest2ByteArray)}");
            Console.WriteLine($"pbTest1ByteArray sum:{pbTest1ByteArray.Select(m => int.Parse(m.ToString())).Sum()}");
            Console.WriteLine($"pbTest2ByteArray sum:{pbTest2ByteArray.Select(m => int.Parse(m.ToString())).Sum()}");

        }

        private static int ObjToArraySize(object o)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, o);
                ms.Close();

                var arr = ms.ToArray();
                return arr.Length;
            }

        }
    }
}
