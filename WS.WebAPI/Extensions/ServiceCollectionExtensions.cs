using System.Text.Json.Serialization;
using WS.Business.Implementations;
using Microsoft.IdentityModel.Tokens;
using Infrastructure.Utilities.Security.JWT;
using System.Text;
namespace WS.WebAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        //appSetting içindekilere ulaşmamız için Iconfiguration'a erişim saglamamız gerekiyor.
        public static void AddAPIServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddControllers()
                .AddJsonOptions(opt =>
                                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            //kontrol işlemleri için appSetting içindeki verileri çektik
            var tokenOption = configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = "Bearer";
                opt.DefaultChallengeScheme = "Bearer";
            }).AddJwtBearer(opt=>
            {
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    //Issuer dogrulaması yap
                    ValidateIssuer = true,
                    //Kontol edecegin deger bu
                    ValidIssuer = tokenOption.Issuer,

                    ValidateAudience = true,
                    ValidAudience = tokenOption.Audience,
                    ValidateLifetime = true,

                    //verify signature kısmını karşılaştır diyoruz.
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOption.SecurityKey)),
                    ClockSkew=TimeSpan.Zero
                };
            });
        }
    }
}
