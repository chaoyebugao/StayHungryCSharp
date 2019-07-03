using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;
using ShOrleans.IGrain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ShOrleans.Client
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("I'm client here.");
            Thread.Sleep(4000);

            return RunMainAsync().Result;
        }

        private static async Task<int> RunMainAsync()
        {
            try
            {
                using (var client = await ConnectClient())
                {
                    await SayHello(client);

                    PaySth(client);

                    Console.ReadKey();
                }

                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nException while trying to run client: {e.Message}");
                Console.WriteLine("Make sure the silo the client is trying to connect to is running.");
                Console.WriteLine("\nPress any key to exit.");
                Console.ReadKey();
                return 1;
            }
        }

        private static async Task<IClusterClient> ConnectClient()
        {
            var client = new ClientBuilder()
                .UseLocalhostClustering()
                .Configure<ClusterOptions>(opts =>
                {
                    opts.ClusterId = "dev";
                    opts.ServiceId = "HelloService";
                }).Build();

            await client.Connect();

            return client;
        }

        private static async Task SayHello(IClusterClient client)
        {
            var friend = client.GetGrain<IHello>(0);

            var res = await friend.SayHello("雷猴");
            Console.WriteLine(res);
        }

        private static Task PaySth(IClusterClient client)
        {
            var person = client.GetGrain<IPerson>(2265);

            person.PaySthAsync().ContinueWith(t =>
            {
                var totalMoney = t.Result;
                Console.WriteLine($"买完了，我的钱还剩：{totalMoney}");
            });

            

            return Task.CompletedTask;
        }
        
    }
}
