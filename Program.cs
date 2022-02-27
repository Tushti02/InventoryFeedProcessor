using InventoryFeedProcessor.FileProcessors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace InventoryFeedProcessor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    IConfiguration configuration = hostContext.Configuration;
                    WorkerOptions options = configuration.Get<WorkerOptions>();
                    
                    services.AddAutoMapper(typeof(ProductsProfile));
                    services.AddTransient<IProcessFileDispatcher, ProcessFileDispatcher>();

                    services.AddSingleton<CapterraProcessor>();
                    services.AddSingleton<SoftwareAdviceProcessor>();
                    services.AddTransient<Func<string, IFileProcessor>>(serviceProvider => key =>
                    {
                        switch (key)
                        {
                            case "yaml":
                                return serviceProvider.GetService<CapterraProcessor>();
                            case "json":
                                return serviceProvider.GetService<SoftwareAdviceProcessor>();
                            default:
                                return serviceProvider.GetService<SoftwareAdviceProcessor>();
                        }
                    });
                    services.AddHostedService<Worker>();
                    services.AddSingleton(options);
                    services.AddHostedService<Worker>();
                    
                });
    }
}
