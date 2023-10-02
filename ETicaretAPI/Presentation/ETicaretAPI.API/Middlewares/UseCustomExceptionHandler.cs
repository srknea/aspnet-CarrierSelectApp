using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace ETicaretAPI.API.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>(); // IExceptionHandlerFeature interface'i üzerinden hatayı yakalıyoruz.
                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => 400, // ClientSideException tipinde bir hata yakalarsak 400 döndürüyoruz.
                        NotFoundException => 404, // NotFoundException tipinde bir hata yakalarsak 404 döndürüyoruz.
                        _ => 500 // Yukarıdaki tiplerden biri değilse 500 döndürüyoruz.
                    };
                    context.Response.StatusCode = statusCode;
                    var response = CustomResponseDto<NoContentDto>.Fail(statusCode, exceptionFeature.Error.Message);
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}
