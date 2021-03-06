using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace PersonalWebsite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    ConfigureSentry(webBuilder);
                });

        private static void ConfigureSentry(IWebHostBuilder webBuilder)
        {
            var dsn = Environment.GetEnvironmentVariable("SENTRY_DSN");
            webBuilder.UseSentry(dsn!);
        }
    }
}