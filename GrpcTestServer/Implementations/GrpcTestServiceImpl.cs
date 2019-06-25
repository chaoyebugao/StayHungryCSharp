using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Service.Model.ExecuteResult;
using GrpcTest.Service.Models;
using GrpcTestServer.Implementations.Interfaces;
using static GrpcTest.Service.GrpcSvc.TestSvc;

namespace GrpcTestServer.Implementations
{
    public class GrpcTestServiceImpl : TestSvcBase, IGrpcSvc
    {
        private long ReqCount { get; set; }

        public long PrintRps(long totalRp, long max)
        {
            var str = $"{totalRp},{max},{ReqCount}";
            var cLen = str.ToString().Length;
            Console.WriteLine(str);
            //Console.SetCursorPosition(Console.CursorLeft - cLen, Console.CursorTop);
            var reqCount = ReqCount;
            ReqCount = 0;
            return reqCount;
        }

        ////一个 简单 RPC ， 客户端使用存根发送请求到服务器并等待响应返回，就像平常的函数调用一样
        public override Task<PbMsgRet> Register1(RegisterRq request, ServerCallContext context)
        {
            ReqCount++;
            var ret = new PbMsgRet()
            {
                ErrCode = GrpcTest.Services.Enumeration.ErrorCodes.Success,
                ErrMsg = "sdsd",
            };
            return Task.FromResult(ret);
        }

        //一个 服务器端流式 RPC ， 客户端发送请求到服务器，拿到一个流去读取返回的消息序列。 客户端读取返回的流，
        //直到里面没有任何消息。从例子中可以看出，通过在 响应 类型前插入 stream 关键字，可以指定一个服务器端的流方法
        public override Task Register2(RegisterRq request, IServerStreamWriter<PbMsgRet> responseStream, ServerCallContext context)
        {
            return Task.Run(async () =>
            {
                ReqCount++;
                var ret = new PbMsgRet()
                {
                    ErrCode = GrpcTest.Services.Enumeration.ErrorCodes.Success,
                    ErrMsg = "sdsd",
                };

                //服务端两次流写入
                await responseStream.WriteAsync(ret);
                ret.ErrMsg = "sdsd2";
                await responseStream.WriteAsync(ret);
            });
        }

        //一个 客户端流式 RPC ， 客户端写入一个消息序列并将其发送到服务器，同样也是使用流。一旦客户端完成写入消息，
        //它等待服务器完成读取返回它的响应。通过在 请求 类型前指定 stream 关键字来指定一个客户端的流方法
        public override Task<PbMsgRet> Register3(IAsyncStreamReader<RegisterRq> requestStream, ServerCallContext context)
        {
            return Task.Run(async () =>
            {
                ReqCount++;

                while (await requestStream.MoveNext(context.CancellationToken))
                {
                    //客户端有两次流写入，因此有两次流读取，因此这里输入Data、Data2
                    Console.WriteLine(requestStream.Current.Name);
                }

                Console.WriteLine("开始返回结果");

                return new PbMsgRet()
                {
                    ErrMsg = "Register3好嗨哟!",
                };
            });
        }

        //一个 双向流式 RPC 是双方使用读写流去发送一个消息序列。两个流独立操作，因此客户端和服务器
        //可以以任意喜欢的顺序读写：比如， 服务器可以在写入响应前等待接收所有的客户端消息，或者可以交替 的读取和写入消息，
        //或者其他读写的组合。每个流中的消息顺序被预留。你可以通过在请求和响应前加 stream 关键字去制定方法的类型
        public override Task Register4(IAsyncStreamReader<RegisterRq> requestStream, IServerStreamWriter<PbMsgRet> responseStream, ServerCallContext context)
        {
            return Task.Run(async () =>
            {
                ReqCount++;

                while (await requestStream.MoveNext(context.CancellationToken))
                {
                    //客户端有两次流写入，因此有两次流读取，因此这里输入Data、Data2
                    Console.WriteLine(requestStream.Current.Name);
                }

                Console.WriteLine("开始返回结果");

                var ret = new PbMsgRet()
                {
                    ErrCode = GrpcTest.Services.Enumeration.ErrorCodes.Success,
                    ErrMsg = "sdsd",
                };

                //服务端两次流写入
                await responseStream.WriteAsync(ret);
                ret.ErrMsg = "sdsd2";
                await responseStream.WriteAsync(ret);
            });
        }

    }
}
