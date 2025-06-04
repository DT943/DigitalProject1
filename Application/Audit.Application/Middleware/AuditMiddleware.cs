 
using Audit.Data.DbContext;
using Microsoft.Extensions.DependencyInjection;


 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
namespace Audit.Application.Middleware
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
            // 1. Capture request info
            string userToken = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last() ?? "No Token";
            var endpoint = context.GetEndpoint();
            string controllerName = endpoint?.Metadata.GetMetadata<ControllerActionDescriptor>()?.ControllerName ?? "Unknown";
            string actionName = endpoint?.Metadata.GetMetadata<ControllerActionDescriptor>()?.ActionName ?? "Unknown";
            string request = await FormatRequest(context.Request);
            string response = "";

            // 2. Setup response body capture
            var originalBodyStream = context.Response.Body;
            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            Exception exception = null;

            try
            {
                await _next(context); // May throw
            }
            catch (Exception ex)
            {
                // Capture exception message as response (or handle differently if needed)
                response = $"Unhandled exception: {ex.Message}";
                exception = ex;
                // Rethrow so ExceptionMiddleware can handle it properly
                throw;
            }
            finally
            {
                // Always reset body so next middleware or exception handler can write
                context.Response.Body = originalBodyStream;

                // Try to read the response stream only if it didn't crash early
                try
                {
                    responseBody.Seek(0, SeekOrigin.Begin);
                    response = string.IsNullOrEmpty(response)
                        ? await new StreamReader(responseBody).ReadToEndAsync()
                        : response;

                    responseBody.Seek(0, SeekOrigin.Begin);
                    await responseBody.CopyToAsync(originalBodyStream);
                }
                catch (Exception readEx)
                {
                    response = $"Failed to read response body: {readEx.Message}";
                }

                // 3. Capture user info
                string userIp = context.Request.Headers["X-Real-IP"].FirstOrDefault()
                ?? context.Connection.RemoteIpAddress?.MapToIPv4().ToString()
                ?? "0.0.0.0";
                var user = context.User;
                string userCode = user?.FindFirst("userCode")?.Value ?? "Anonymous";
                string email = user?.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value ?? "Anonymous";
                string userName = user?.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value ?? "Unknown User";
                string userRole = user?.FindFirst(System.Security.Claims.ClaimTypes.Role)?.Value ?? "No Role";

                // 4. Save audit log
                try
                {
                    using var scope = _scopeFactory.CreateScope();
                    var auditDb = scope.ServiceProvider.GetRequiredService<AuditDbContext>();

                    auditDb.AuditLogs.Add(new Audit.Domain.AuditDetails
                    {
                        UserCode = userCode,
                        Email = email,
                        IP = userIp,
                        Token = userToken,
                        userRole = userRole,
                        controllerName = controllerName,
                        actionName = actionName,
                        response = response,
                        request = request,
                        ActionTime = DateTime.Now,
                    });

                    await auditDb.SaveChangesAsync();
                }
                catch (Exception dbEx)
                {
                    Console.WriteLine($"Failed to save audit log: {dbEx.Message}");
                }
            }
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
