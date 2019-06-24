using Grpc.Core;
using GrpcTest.Service.GrpcSvc;
using GrpcTestServer.Implementations;
using GrpcTestServer.Implementations.Interfaces;
using System;
using System.Threading;
using System.Timers;

namespace GrpcTestServer
{
    class Program
    {
        const int port = 9070;

        static long maxRps;
        static long totalRp;

        static void Main(string[] args)
        {
            Console.WriteLine("I'm Server.");

            var grpcTestSvc = new GrpcTestServiceImpl();
            CheckRps(grpcTestSvc);

            var server = new Server
            {
                Services = { TestSvc.BindService(grpcTestSvc) },
                Ports = { new ServerPort("127.0.0.1", port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine($"gRPC server listening on port {port}");
            Console.WriteLine("任意键退出...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();

        }

        private static void CheckRps(IGrpcSvc svc)
        {
            var timer = new System.Timers.Timer(1000);
            
            timer.Elapsed += (s, e) =>
            {
                var rps = svc.PrintRps(totalRp, maxRps);
                totalRp = totalRp + rps;
                if (rps > maxRps)
                {
                    maxRps = rps;
                }
            };
            timer.Start();
        }
    }
}
