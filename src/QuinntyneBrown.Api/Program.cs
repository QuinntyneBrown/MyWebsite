using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QuinntyneBrown.Infrastructure.Data;
using System;
using System.Linq;

namespace QuinntyneBrown.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            ProcessDbCommands(args, host);

            host.Run();
        }

        private static void ProcessDbCommands(string[] args, IHost host)
        {
            var services = (IServiceScopeFactory)host.Services.GetService(typeof(IServiceScopeFactory));

            using (var scope = services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<QuinntyneBrownDbContext>();
                var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();

                if (args.Contains("ci"))
                    args = new string[4] { "dropdb", "createdb", "seeddb", "stop" };

                if (args.Contains("dropdb"))
                {
                    context.Database.EnsureDeleted();
                }

                if (args.Contains("createdb"))
                {
                    context.Database.EnsureCreated();
                }

                if (args.Contains("seeddb"))
                {
                    SeedData.Seed(context);
                }
                if (args.Contains("stop"))
                    Environment.Exit(0);
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
