using Scalar.AspNetCore;
using Microsoft.AspNetCore.HttpOverrides;
using Serilog;
using Steam.Web.Api.Extensions;
using Steam.Web.Api.Middleware;
using SteamApplication.Interfaces.Servicie;

var builder = WebApplication.CreateBuilder(args);
const string FrontendCorsPolicy = "FrontendCorsPolicy";

builder.Host.UseSerilog();

await builder.Services.AddCore(builder.Configuration);

builder.Services.AddSingleton<SteamApplication.Servicios.EmailTemplates.EmailTemplateData>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(FrontendCorsPolicy, policy =>
    {
        policy.WithOrigins(
                "http://localhost:4200",
                "http://127.0.0.1:4200",
                "http://localhost:4300",
                "http://127.0.0.1:4300",
                "http://localhost:4600",
                "http://127.0.0.1:4600")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var userService = scope.ServiceProvider.GetRequiredService<IUserService>();
    var emailTemplateService = scope.ServiceProvider.GetRequiredService<IEmailTemplateService>();

    await emailTemplateService.Init();
    await userService.CreateFirstUser();
}

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference("/scalar", options =>
    {
        options.WithTitle("STEAM API")
               .WithOpenApiRoutePattern("/openapi/{documentName}.json");
    });
}

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseCors(FrontendCorsPolicy);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
