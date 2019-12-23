using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using reactapp.Manager.Contract;
using reactapp.Manager.Service;
using reactapp.Repository;
using reactapp.Repository.Contracts;
using reactapp.Repository.Services;
using System.Security.Principal;

namespace reactapp
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
