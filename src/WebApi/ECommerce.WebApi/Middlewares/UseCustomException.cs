using Microsoft.AspNetCore.Diagnostics;
using ECommerce.Application.Common.Exceptions;
using ECommerce.Application.Dtos;
using ECommerce.Application.Wrapper;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace ECommerce.WebApi.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException<T>(this IApplicationBuilder app, ILogger<T> logger)
        {
            app.UseExceptionHandler(config =>
            {

                config.Run(async context =>
                {
                    context.Response.ContentType = MediaTypeNames.Application.Json;

                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (exceptionFeature is not null)
                    {
                        var statusCode = exceptionFeature.Error switch
                        {
                            NotFoundException => (int)HttpStatusCode.NotFound,
                            BadRequestException => (int)HttpStatusCode.BadRequest,                            
                            _ => (int)HttpStatusCode.InternalServerError,
                        };
                        context.Response.StatusCode = statusCode;

                        var response = CustomResponseDto<NoContentDto>.Fail(statusCode, exceptionFeature.Error.Message);
                        logger.LogError(exceptionFeature.Error.Message);
                        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                    }

                });

            });
        }
    }
}
