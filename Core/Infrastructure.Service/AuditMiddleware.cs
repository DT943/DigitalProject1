using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core.Tokenizer;
using System.Text;
using System.Threading.Tasks;
using Audit.Data.DbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Service
{
    public class AuditMiddleware
    {
        private readonly RequestDelegate _next;
        // private AuditDbContext auditDb;
        private IServiceScopeFactory _scopeFactory;
        public AuditMiddleware(RequestDelegate next, IServiceScopeFactory scopeFactory)
        {
            _next = next;
            _scopeFactory = scopeFactory;

        }

        public async Task InvokeAsync(HttpContext context)
        {

            string userToken = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last() ?? "No Token";

            // Extracting Claims
            var user = context.User;
            string userCode = user?.FindFirst("userCode")?.Value ?? "Anonymous";
            string userName = user?.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value ?? "Unknown User";
            string userRole = user?.FindFirst(System.Security.Claims.ClaimTypes.Role)?.Value ?? "No Role";



            var endpoint = context.GetEndpoint();
            string controllerName = endpoint?.Metadata.GetMetadata<ControllerActionDescriptor>()?.ControllerName ?? "Unknown";
            string actionName = endpoint?.Metadata.GetMetadata<ControllerActionDescriptor>()?.ActionName ?? "Unknown";
            var request = await FormatRequest(context.Request);
            var originalBodyStream = context.Response.Body;
            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;
            await _next(context);
            var response = await FormatResponse(context.Response);

            using (var scope = _scopeFactory.CreateScope())
            {
                var auditDb = scope.ServiceProvider.GetRequiredService<AuditDbContext>();
                    try
                    {
                        auditDb.AuditLogs.Add(new Audit.Domain.AuditDetails
                        {
                            UserCode = userCode,
                            Token = userToken,
                            userRole = userRole,
                            controllerName = controllerName,
                            actionName = actionName,
                            response = response,
                            request = request,
                            ActionTime = DateTime.Now

                        });

                        await auditDb.SaveChangesAsync();

                    }
                    catch (Exception e)
                    {

                    }
            }


            await responseBody.CopyToAsync(originalBodyStream);
        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            request.EnableBuffering();
            var body = await new StreamReader(request.Body).ReadToEndAsync();
            request.Body.Position = 0;
            return $"{request.Method} {request.Path} {request.QueryString} {body}";
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            var body = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);
            return $"{response.StatusCode}: {body}";
        }
    }
}
