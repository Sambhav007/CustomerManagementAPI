using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Serilog;
using System.IO;

using Microsoft.Extensions.Configuration;





namespace Pitstop.CustomerManagementAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder()
                .ConfigureAppConfiguration((buildercontext, config) =>
                {
                    config.AddJsonFile("settings/appsettings_customersecret.json", optional: true);
                })
                .UseSerilog()
                .UseHealthChecks("/hc")
                .UseStartup<Startup>()
                .Build();
        }
    }
}