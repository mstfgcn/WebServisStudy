using Infrastructure.Utilities;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;
using WS.Business.CustomExceptions;
using WS.Model.Dtos.Product;

namespace WS.WebAPI.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            //.net içindeki  exceptionları yakalaybilen bir middleware
            //çalışmaya başlayınca böyle bir yanıt döndüreceksin diyoruz.
            app.UseExceptionHandler(config =>
            {
      
                //Run metodu response u döndurmek için kullanılır.
                //burda responsu hazırlamamız gerekiyor. bu nesneyi oluşturmak için
                /* -Oluşan hatayı ilk olarak yakalamamız gerekiyor.
                 * -Hata mesajı döndürmeliyiz.
                 * -Response içerisinde bir durum kotu döndurmemiz gerekiyor. */ 
            
                config.Run(async context =>
                {
                    //try-catch içerisindeki yakaladıgımız exceptionı mdlware içerisinde bu şekilde yakalıyoruz.
                    //Yakalanan exception tipindeki nesneyi elimeze alıyoruz.
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    //oluşan hataya aşagıdaki gibi erişiyoruz.
                    var exception = exceptionFeature.Error;

                    //varsayılan olarak durum kodu setliyoruz.
                    var statusCode = StatusCodes.Status500InternalServerError;
                    switch (exception)
                    {
                        case BadRequestException:
                            statusCode = StatusCodes.Status400BadRequest;
                            break;

                        case NotFoundException:
                            statusCode = StatusCodes.Status404NotFound;
                            break;
                        default:
                            break;
                    }

                    // durum kodu ve content tipinin json formatında olacagını belirtiyoruz.
                   
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = statusCode;

                    //responsumuzu oluşturuyoruz.
                    var response = ApiResponse<NoData>.Fail(statusCode, exception.Message);
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));

                });
            });
        }
    }
}
