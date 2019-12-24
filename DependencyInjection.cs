using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReactApi.Manager.Contract;
using ReactApi.Manager.Service;
using ReactApi.Repository;
using ReactApi.Repository.Contracts;
using ReactApi.Repository.Services;
using System.Security.Principal;

namespace ReactApi
{
    /// <summary>
    /// Class used to configure the repository classes
    /// </summary>
    public class DependencyInjection
    {
        internal void ConfigureRepositories(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ReactAppContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IPrincipal>(provider => provider.GetService<IHttpContextAccessor>().HttpContext.User);

            #region Manager
            services.AddTransient<IGroceryService, GroceryService>();
            #endregion

            #region Repositories
            services.AddTransient<IGroceryRepository, GroceryRepository>();

            #endregion

        }
    }
}
