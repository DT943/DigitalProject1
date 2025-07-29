using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Authentication.Application.Middleware
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantMiddleware(RequestDelegate next) => _next = next;

        public async Task Invoke(HttpContext context)
        {


            var path = context.Request.Path.Value;

            // Exclude /SearchRequest (case-insensitive match)
            if (path.Equals("/Authentication/login", StringComparison.OrdinalIgnoreCase))
            {
                await _next(context); // skip tenant check
                return;
            }
            var excludedPaths = new[]
                {
                     "/Authentication/LogInWithOTP",
                     "/Authentication/FirstResetPassword"

                 };

            if (excludedPaths.Any(p => path.Equals(p, StringComparison.OrdinalIgnoreCase)))
            {
                await _next(context);
                return;
            }



            var user = context.User;
            var tenantClaim = user.FindFirst("tenant_id")?.Value;
            
            if (tenantClaim != "1")
            {
                context.Response.StatusCode = 403; // Forbidden
                await context.Response.WriteAsync("Invalid tenant context.");
                return;
            }

            await _next(context);
        }
    }
}
