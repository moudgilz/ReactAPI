using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using reactapp.Helpers;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace reactapp
{
    /// <summary>
    /// Program class
    /// </summary>
    public class Program
    {
        private static readonly string DotnetEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        /// <summary>
        /// main method
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
               .Enrich.FromLogContext()
               .MinimumLevel.Debug()
               .WriteTo.ColoredConsole(LogEventLevel.Verbose, "{NewLine}{Timestamp:HH:mm:ss} [{Level}] ({CorrelationToken}) {Message}{NewLine}{Exception}")
               .CreateLogger();

            try
            {
                CreateWebHostBuilder(args).Build().MigrateDatabase().Run();
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        /// <summary>
        /// web host builder
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                          .ConfigureAppConfiguration((hostingContext, config) =>
                          {
                              ConfigureAppConfig(args, config);
                          })
                          .UseSerilog()
                          .UseStartup<Startup>();
        }

        #region Private methods

        /// <summary>
        /// Configure app config
        /// </summary>
        /// <param name="args"></param>
        /// <param name="config"></param>
        private static void ConfigureAppConfig(string[] args, IConfigurationBuilder config)
        {
            var inMemDictionary = new Dictionary<string, string>
            {
                //  {"AzureOfferPortal:Audience", Environment.GetEnvironmentVariable("AAD_OfferPortal_Audience")},
                //  {"AzureOfferPortal:Authority", Environment.GetEnvironmentVariable("AAD_OfferPortal_Authority")}
            };

            try
            {
                config.SetBasePath(Directory.GetCurrentDirectory());
                config.AddInMemoryCollection(inMemDictionary);
                config.AddJsonFile("appsettings.json", false, true);
                config.AddJsonFile($"appsettings.{DotnetEnvironment}.json", true);
                config.AddEnvironmentVariables();
            }
            catch
            {
                // If the initialization causes the exception
                // "FileNotFoundException: The configuration file 'appsettings.json' was not found and is not optional."
                // it probably means your system has a Visual Studio installation from March 2018 or newer, in which case
                // the traditional meaning of GetCurrentDirectory is no longer valid, so we must make adjustments.
                config.SetBasePath(Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"../../../")));
                config.AddInMemoryCollection(inMemDictionary);
                config.AddJsonFile("appsettings.json", false, true);
                config.AddJsonFile($"appsettings.{DotnetEnvironment}.json", true);
                config.AddEnvironmentVariables();
            }
        }

        #endregion
    }
}
