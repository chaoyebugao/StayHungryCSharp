using Grpc.Core;
using GrpcTest.Service.GrpcSvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GrpcTest.Client
{
    class Program
    {
        const int port = 9070;

        static void Main(string[] args)
        {
            //脚本生成在统一脚本处理引擎
            //服务端流式可以参考：https://www.cnblogs.com/lonelyxmas/p/10297004.html

            Console.WriteLine("I'm Client.");
            Thread.Sleep(1000);

            var channel = new Channel("127.0.0.1", port, ChannelCredentials.Insecure);
            var client = new TestSvc.TestSvcClient(channel);
            Console.WriteLine("客户端服务已开启，输入exit退出");

            var p = 100;//150000

            #region Register1

            ////当p = 150000时，Max为15142
            //for (var i = 0; i < p; i++)
            //{
            //    var call = client.Register1Async(new Service.Models.RegisterRq()
            //    {
            //        Age = 17,
            //        AnnualIncome = 343434D,
            //        Email = "dfsfsdfsdf@qq.com",
            //        Gender = true,
            //        Name = "Data",
            //        Phone = "3434334",
            //    });
            //}

            ////当p = 150000时，Max为15642
            //for (var i = 0; i < p; i++)
            //{
            //    Task.Run(() =>
            //    {
            //        var call = client.Register1Async(new Service.Models.RegisterRq()
            //        {
            //            Age = 17,
            //            AnnualIncome = 343434D,
            //            Email = "dfsfsdfsdf@qq.com",
            //            Gender = true,
            //            Name = "Data",
            //            Phone = "3434334",
            //        });
            //    });
            //}

            ////当p = 150000时，Max为15842
            //for (var i = 0; i < p; i++)
            //{
            //    ThreadPool.QueueUserWorkItem((s) =>
            //    {
            //        var call = client.Register1Async(new Service.Models.RegisterRq()
            //        {
            //            Age = 17,
            //            AnnualIncome = 343434D,
            //            Email = "dfsfsdfsdf@qq.com",
            //            Gender = true,
            //            Name = "Data",
            //            Phone = "3434334",
            //        });
            //    });
            //}

            ////当p = 150000时，Max为15642
            //Parallel.For(0, p, (i, s) =>
            //{
            //    var call = client.Register1Async(new Service.Models.RegisterRq()
            //    {
            //        Age = 17,
            //        AnnualIncome = 343434D,
            //        Email = "dfsfsdfsdf@qq.com",
            //        Gender = true,
            //        Name = "Data",
            //        Phone = "3434334",
            //    });
            //});
            #endregion

            #region Register2

            //var ck = new CancellationToken();

            ////当p = 150000时，Max为9500
            //Parallel.For(0, p, async (i, s) =>
            //{
            //    using (var call = client.Register2(new Service.Models.RegisterRq()
            //    {
            //        Age = 17,
            //        AnnualIncome = 343434D,
            //        Email = "dfsfsdfsdf@qq.com",
            //        Gender = true,
            //        Name = "Data",
            //        Phone = "3434334",
            //    }, cancellationToken: ck))
            //    {
            //        using (var resStream = call.ResponseStream)
            //        {
            //            while (await resStream.MoveNext(ck))
            //            {
            //                Console.WriteLine(resStream.Current.ErrMsg);
            //                //服务端有两次流写入，因此客户端有两次流读取
            //                //因此输出：sdsd、sdsd2
            //            }
            //        }
            //    }
            //});

            #endregion

            #region Register3

            //var ck = new CancellationToken();

            ////当p = 150000时，Max为8500
            //Parallel.For(0, p, async (i, s) =>
            //{
            //    using (var call = client.Register3())
            //    {
            //        var ret = new Service.Models.RegisterRq()
            //        {
            //            Age = 17,
            //            AnnualIncome = 343434D,
            //            Email = "dfsfsdfsdf@qq.com",
            //            Gender = true,
            //            Name = "Data",
            //            Phone = "3434334",
            //        };
            //        //客户端两次流写入
            //        await call.RequestStream.WriteAsync(ret);
            //        ret.Name = "Data2";
            //        await call.RequestStream.WriteAsync(ret);
            //        await call.RequestStream.CompleteAsync();
            //        //var r1 = await call.ResponseAsync;
            //        //Console.WriteLine($"{r1.ErrMsg}{DateTime.Now.ToString("fff")}");
            //    }
            //});

            #endregion

            #region Register4

            var ck = new CancellationToken();

            //当p = 150000时，Max为8500
            Parallel.For(0, p, async (i, s) =>
            {
                using (var call = client.Register4())
                {
                    var ret = new Service.Models.RegisterRq()
                    {
                        Age = 17,
                        AnnualIncome = 343434D,
                        Email = "dfsfsdfsdf@qq.com",
                        Gender = true,
                        Name = "Data",
                        Phone = "3434334",
                    };
                    //客户端两次流写入
                    await call.RequestStream.WriteAsync(ret);
                    ret.Name = "Data2";
                    await call.RequestStream.WriteAsync(ret);
                    await call.RequestStream.CompleteAsync();

                    using (var resStream = call.ResponseStream)
                    {
                        while (await resStream.MoveNext(ck))
                        {
                            Console.WriteLine(resStream.Current.ErrMsg);
                            //服务端有两次流写入，因此客户端有两次流读取
                            //因此输出：sdsd、sdsd2
                        }
                    }


                }
            });

            #endregion





            Console.WriteLine("回车结束");
            Console.ReadLine();
        }
    }
}
