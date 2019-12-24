using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ReactApi.Helpers.Security;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using ReactApi.Helpers;
namespace ReactApi
{
    /// <summary>
    /// class start up
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Start up
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="environment"></param>
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;

            SwaggerInfo = new Info();
            Configuration.GetSection("ApplicationInfo").Bind(SwaggerInfo);
        }

        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Environment
        /// </summary>
        public IHostingEnvironment Environment { get; }

        /// <summary>
        /// swagger info
        /// </summary>
        public Info SwaggerInfo { get; set; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Add AllowAll policy 
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                   builder =>
                   {
                       builder.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
                   });
            });
            services.AddAzureAdAuthorization(Configuration);

            services.AddHttpContextAccessor();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowAll"));
            });

            if (!Environment.IsProduction())
            {
                ConfigureSwagger(services);
            }

            new DependencyInjection().ConfigureRepositories(services, Configuration);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="logger"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "api/swagger/{documentName}/swagger.json";
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/api/swagger/v1.0/swagger.json", "Versioned API v1.0");
                c.RoutePrefix = "api/swagger";
                c.DocExpansion(DocExpansion.None);
            });

            // For availability of Hosting env in static classes etc..
            Helpers.AppHelper.HostingEnvironment = env;
            Helpers.AppHelper.Configuration = Configuration;
            Helpers.AppHelper.ServiceProvider = app.ApplicationServices;

            // global error handling ..
            app.ConfigureExceptionHandler(logger);

            app.UseMvc();
            // For content not managed within MVC. You may want to set the Cors middleware
            // to use the same policy.
            app.UseCors("AllowAll");
        }

        #region Private methods

        /// <summary>
        /// swagger configuration
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureSwagger(IServiceCollection services)
        {
            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", SwaggerInfo);

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });

                // To enable token acceptance in authorization; Swagger 2.+ support
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", new string[] { } }
                });

                // add documentation to Swagger api
                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var commentsFileName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".xml";
                var commentsFile = Path.Combine(baseDirectory, commentsFileName);

                c.IncludeXmlComments(commentsFile);

            });
        }

        #endregion

    }
}
