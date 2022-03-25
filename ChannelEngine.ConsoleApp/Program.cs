using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using ChannelEngine.Shared.Models;
using ChannelEngine.Integration.MerchantAPI;
using ChannelEngine.Core.Interface;
using Newtonsoft.Json;
using System.Linq;

namespace ChannelEngine.ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var host = AppStartup();

                var orderService = host.Services.GetRequiredService<IOrderService>();
                var productService = host.Services.GetRequiredService<IProductService>();
                var ordersInProgress = await orderService.GetOrdersInProgressAsync();
                var topOrdersInProgress = orderService.GetTopOrdersInProgress(ordersInProgress, 5);
                var orderToUpdate = topOrdersInProgress.FirstOrDefault();
                if (orderToUpdate != null)
                    Console.WriteLine(await productService.UpdateProductStockAsync(orderToUpdate.TotalQuantity, orderToUpdate.StockLocationId.Value, orderToUpdate.MerchantProductNo));

                Console.WriteLine(JsonConvert.SerializeObject(ordersInProgress));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static IHost AppStartup()
        {
            var builder = new ConfigurationBuilder();
            BuildAppSettingsConfig(builder);

            var host = Host.CreateDefaultBuilder()  
                        .ConfigureServices((context, services) => {
                            services.AddScoped<IOrderService, OrderService>();
                            services.AddScoped<IProductService, ProductService>();
                            services.Configure<AppConfiguration>(context.Configuration.GetSection(nameof(AppConfiguration)));
                            services.AddHttpClient("channelengineapi", httpClient =>
                            {
                                httpClient.BaseAddress = new Uri(context.Configuration[$"{nameof(AppConfiguration)}:ChannelEngineAPIBaseUrl"]);
                            });
                }).Build(); 

            return host;
        }

        static void BuildAppSettingsConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
        }
    }
}
