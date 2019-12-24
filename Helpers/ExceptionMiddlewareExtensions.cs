using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ReactApi.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ReactApi.Helpers
{
    /// <summary>
    /// Handling Errors Globally with the Built-In Middleware
    /// </summary>
    public static class ExceptionMiddlewareExtensions
    {
        /// <summary>
        /// configire global error handling 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="logger"></param>
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger<Startup> logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {                    
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.LogError($"Something went wrong: {contextFeature.Error}");

                        await context.Response.WriteAsync(new Result()
                        {

                            Status = Status.Error,
                            Message = contextFeature.Error != null ? contextFeature.Error.Message : "Internal Server Error.",
                            StatusCode = (HttpStatusCode)context.Response.StatusCode
                        }.ToString());
                    }
                });
            });
        }
    }
}
