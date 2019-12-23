using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace reactapp.Helpers
{
    /// <summary>
    /// Application helper methods
    /// </summary>
    public static class AppHelper
    {
        /// <summary>
        /// hosting env
        /// </summary>
        public static IHostingEnvironment HostingEnvironment { get; set; }

        /// <summary>
        /// Configuration
        /// </summary>
        public static IConfiguration Configuration { get; set; }

        /// <summary>
        /// Service provider for geeting injected services
        /// </summary>
        public static IServiceProvider ServiceProvider { get; set; }

        /// <summary>
        /// Current date time
        /// </summary>
        public static DateTime CurrentDate => DateTime.Now;

        /// <summary>
        /// Get logged user claims
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static UserClaim GetUserClaimDetails(ClaimsIdentity identity)
        {
            UserClaim userClaim = null;
            if (identity != null)
            {
                if (identity.Claims.Any())
                {
                    IEnumerable<Claim> claims = identity.Claims;

                    userClaim = new UserClaim
                    {
                        Name = identity.FindFirst("Name").Value
                    };
                    var emailClaim = identity.FindFirst(ClaimTypes.Email) ?? identity.FindFirst(ClaimTypes.Upn);
                    userClaim.Email = emailClaim.Value;
                }
            }
            return userClaim;
        }

        /// <summary>
        /// Gets the column value.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public static object GetColumnValue(String columnName, object entity)
        {
            var pinfo = entity.GetType().GetProperty(columnName);
            if (pinfo == null) { return null; }
            return pinfo.GetValue(entity, null);
        }

        /// <summary>
        /// Sets the column value.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="entity">The entity.</param>
        /// <param name="value">The value.</param>
        public static void SetColumnValue(String columnName, object entity, object value)
        {
            var pinfo = entity.GetType().GetProperty(columnName);
            if (pinfo != null) { pinfo.SetValue(entity, value, null); }
        }

        /// <summary>
        /// Maps the audit columns.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="identity"></param>
        public static void MapAuditColumns(this object model, ClaimsIdentity identity)
        {
            if (identity != null)
            {
                var authorizedInfo = GetUserClaimDetails(identity);
                if (model != null && authorizedInfo != null)
                {
                    var emailId = authorizedInfo.Email;
                    var createdBy = Convert.ToString(GetColumnValue(Constants.CreatedBy, model));
                    if (string.IsNullOrEmpty(createdBy))
                    {
                        // SetColumnValue(Constants.IsActiveColumn, model, true);
                        SetColumnValue(Constants.CreatedDate, model, CurrentDate);
                        SetColumnValue(Constants.CreatedBy, model, emailId);
                    }
                    SetColumnValue(Constants.ModifiedDate, model, CurrentDate);
                    SetColumnValue(Constants.ModifiedBy, model, emailId);
                }
            }
        }

    }
}