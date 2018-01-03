using Google.Protobuf;
using Google.Protobuf.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            Console.WriteLine($"reqByteArray:{Encoding.UTF8.GetString(reqByteArray)}");
            Console.WriteLine($"reqNewtonJson:{reqNewtonJson}, reqNewtonJson Length:{reqNewtonJson.Length}");
            Console.WriteLine($"reqProtobufJson:{reqProtobufJson}, reqProtobufJson Length:{reqProtobufJson.Length}");

            Console.WriteLine();
            
            //反序列化
            var req2 = NetRequest.Parser.ParseFrom(reqByteArray);
            req2.Params.Add("RealName", "朝野布告");
            var req2Size = req2.CalculateSize();
            var req2ProtobufJson = JsonFormatter.Default.Format(req2);
            Console.WriteLine($"req2Size:{req2Size}");
            Console.WriteLine($"req2ProtobufJson:{req2ProtobufJson}, req2ProtobufJson Length:{req2ProtobufJson.Length}");





        }
    }
}
