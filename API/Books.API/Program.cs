using Books.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Books.API
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<DataContext>();
                await context.Database.MigrateAsync();
            }
            catch(Exception e)
            {
                var logger = services.GetRequiredService<ILogger>();
                logger.LogError(e, "An error occured during migration");
            }
            finally
            {
                await host.RunAsync().ConfigureAwait(false);
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json");
#if !DEBUG
                    //var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("VaultUri"));
                    //config.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());
#endif
                })
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
    }
}
