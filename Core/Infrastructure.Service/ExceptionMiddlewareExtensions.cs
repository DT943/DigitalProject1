using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Service
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    if (contextFeature != null)
                    {
                        var ex = contextFeature.Error;

                        // Handle CustomValidationException with ValidationProblemDetails
                        if (ex is CustomValidationException customValidationEx)
                        {
                            var problem = customValidationEx.ProblemDetails;
                            context.Response.StatusCode = problem.Status ?? StatusCodes.Status400BadRequest;
                            problem.Extensions["traceId"] = context.TraceIdentifier;
                            await context.Response.WriteAsJsonAsync(problem);
                            return;
                        }
                        // Handle CustomValidationException with ValidationProblemDetails


                        ApiResponse<object> apiResponse = ErrorDetails<object>.CreateErrorResponse(contextFeature.Error);
                        context.Response.StatusCode = apiResponse.StatusCode;
                        await context.Response.WriteAsync(apiResponse.ToString());
                    }
                });
            });
        }
    }
}
