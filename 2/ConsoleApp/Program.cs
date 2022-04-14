using System.Threading.Tasks;
using Application;
using ConsoleApp.Utils;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ConsoleApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var hostBuilder = CreateHostBuilder(args);

            await hostBuilder.RunConsoleAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureLogging((logging) =>
                {
                    logging.ClearProviders();
                })
                .ConfigureServices(services =>
                {
                    services.AddInfrastructure();
                    services.AddApplication();
                    services.AddSingleton<IHostedService, Ui>();
                });
        }
    }
}