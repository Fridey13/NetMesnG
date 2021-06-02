using System;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace NetMesnG.Api.Extensions
{
    public static class ExceptionHandlerExtension
    {
        public static void ExceptionHandling(this IApplicationBuilder builder)
        {
            builder.UseExceptionHandler(errorBuilder =>
            {
                errorBuilder.Use(async (context, func) =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var error = contextFeature.Error;
                        var message = error.Message;
                        var stackTrace = error.StackTrace;
                        var code = HttpStatusCode.InternalServerError;
                        //ToDo: write logs.

                        switch (error)
                        {
                            case Exception _:
                                code = HttpStatusCode.InternalServerError;
                                message = "Internal server error"; //Messages.InternalServerError;
                                break;
                            default:
                                break;
                        }

                        context.Response.ContentType = "application/json";
                        context.Response.StatusCode = (int) code;
                        await context.Response.WriteAsync(message);
                    }
                });
            });
        }
    }
}