using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using static System.String;

namespace ReactApi.Helpers.Security
{
    /// <summary>
    /// Azure Ad extension
    /// </summary>
    public static class AzureAdExtensions
    {
        /// <summary>
        /// In development mode, we must ensure that unauthenticated users have access.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static IServiceCollection AddAzureAdAuthorization(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(option =>
                {
                    option.Authority = Format(configuration["AzureAd:AadInstance"], configuration["AzureAd:Tenant"]);
                    option.Audience = configuration["AzureAD:Audience"];
                    option.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = context => Task.CompletedTask,
                        OnAuthenticationFailed = context =>
                        {
                            Log.Warning("Failed to validate authorization token: {MSG}", context.Exception.Message);
                            return Task.CompletedTask;
                        }
                    };
                });

            return services;
        }
      
    }
}