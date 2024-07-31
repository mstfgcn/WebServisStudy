using WS.Business.Extensions;
using WS.WebAPI.Extensions;
using WS.WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAPIServices(builder.Configuration);
// IoC REGISTRATION
builder.Services.AddBusinessServices();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}


//[Authorize ]in çalýþabilmesi için bu 2 middleware eklenmesi gerekiyor.
app.UseAuthentication();
app.UseAuthorization();
//----------------------------------------------------------------------

app.MapControllers();

app.UseCustomException();//Hazýrladýgýmýz
app.Run();
