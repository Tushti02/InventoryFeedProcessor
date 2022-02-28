using InventoryFeedProcessor.FileProcessors;
using InventoryFeedProcessor.Infrastructure;
using InventoryFeedProcessor.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace InventoryFeedProcessor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                IConfiguration configuration = hostContext.Configuration;
                WorkerOptions options = configuration.Get<WorkerOptions>();

                string mySqlConnectionStr = configuration.GetConnectionString("InventoryDatabase");
                services.AddDbContext<ProductContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)),contextLifetime:ServiceLifetime.Transient
                    ,optionsLifetime:ServiceLifetime.Transient);
                services.AddTransient<DbContext, ProductContext>();                

                services.AddAutoMapper(typeof(ProductsProfile));
                services.AddTransient<IProcessFileDispatcher, ProcessFileDispatcher>();

                services.AddTransient<IProductRepository, ProductRepository>();
                services.AddTransient<IUnitOfWork, UnitOfWork>();
                services.AddTransient<IRepository<Product>, Repository<Product>>();


                services.AddTransient<CapterraProcessor>();
                services.AddTransient<SoftwareAdviceProcessor>();
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

            });
        }
    }
}
