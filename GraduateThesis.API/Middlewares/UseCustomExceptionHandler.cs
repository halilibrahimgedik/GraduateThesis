using GraduateThesis.Core.Dtos.CustomResponseDtos;
using GraduateThesis.Service.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace GraduateThesis.API.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(configure =>
            {
                configure.Run(async context =>
                {
                    context.Response.ContentType = MediaTypeNames.Application.Json; /*"application/json"*/

                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (exceptionFeature != null)
                    {
                        context.Response.StatusCode = exceptionFeature.Error switch
                        {
                            ClientSideException => StatusCodes.Status400BadRequest,
                            NotFoundException => StatusCodes.Status404NotFound,
                            _ => StatusCodes.Status500InternalServerError
                        };

                        var createResponse = CustomResponseDto<NoDataDto>.Fail(context.Response.StatusCode, exceptionFeature.Error.Message);
                        await context.Response.WriteAsync(JsonSerializer.Serialize(createResponse));
                    }
                });
            });
        }
    }
}
