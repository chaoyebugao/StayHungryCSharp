using Microsoft.Extensions.DependencyInjection;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;
using ShOrleans.Grain;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ShOrleans.Host
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("I'm silo here.");
            return RunMainAsync().Result;
        }

        private static async Task<int> RunMainAsync()
        {
            try
            {
                var host = await StartSilo();
                Console.WriteLine("\n\n Press Enter to terminate...\n\n");
                Console.ReadLine();

                await host.StopAsync();

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 1;
            }
        }


        async static Task<ISiloHost> StartSilo()
        {
            var builder = new SiloHostBuilder()
                .UseLocalhostClustering()
                .AddMemoryGrainStorage("DevStore")
                .Configure<ClusterOptions>(opts =>
                {
                    opts.ClusterId = "dev";
                    opts.ServiceId = "HelloService";
                })
                .Configure<EndpointOptions>(opts =>
                {
                    opts.AdvertisedIPAddress = IPAddress.Loopback;
                })
                .ConfigureApplicationParts(p =>
                {
                    p.AddApplicationPart(typeof(HelloGrain).Assembly).WithReferences();
                    p.AddApplicationPart(typeof(PersonGrain).Assembly).WithReferences();
                });

            var host = builder.Build();
            await host.StartAsync();
            return host;
        }

    }
}
