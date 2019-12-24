using System;
using System.Diagnostics;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace ReactApi.Repository
{
    /// <summary>
    /// To Enable migration; IDesignTimeDbContextFactory need to be implemented
    /// </summary>
    public class ReactAppContextFactory : IDesignTimeDbContextFactory<ReactAppContext>
    {      
        private static IConfiguration _configuration;
        private static readonly string DotnetEnvironment =  Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        /// <summary>
        /// CTOR of context factory
        /// </summary>
        public ReactAppContextFactory()
        {
            Debugger.Launch();

            Log.Logger.Debug("OfferPortalContextFactory" + Directory.GetCurrentDirectory());
            _configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile($"appsettings.{DotnetEnvironment}.json", false)
               .Build();
        }

        /// <summary>
        /// Create db context
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public ReactAppContext CreateDbContext(string[] args)
        {
            Debugger.Launch();
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<ReactAppContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new ReactAppContext(optionsBuilder.Options);
        }
    }
}
