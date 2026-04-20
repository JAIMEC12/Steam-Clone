using Serilog;
using Steam.Web.Api.Extensions;
using Steam.Web.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCore(builder.Configuration);
builder.Host.UseSerilog();

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

// Inyección de dependencia
//builder.Services.AddSingleton<IUserService, UserService>();

//builder.Services.AddScoped<IUserService, UserService>(); // El método AddScoped registra el servicio con un tiempo de vida "scoped",
// lo que significa que se crea una nueva instancia del servicio
// para cada solicitud HTTP. Esto es útil cuando deseas que cada
// solicitud tenga su propia instancia del servicio, lo que puede ser
// beneficioso para manejar datos específicos de la solicitud o para evitar
// problemas de concurrencia en aplicaciones web.
//builder.Services.AddSingleton<Cache<UserDto>>(); // El método AddSingleton registra el servicio con un tiempo de vida "singleton",
// lo que significa que se crea una única instancia del servicio durante toda la vida de la
// aplicación.
// Esta instancia se comparte entre todas las solicitudes y usuarios. Es útil para servicios
// que no mantienen estado específico de la solicitud y que pueden ser compartidos de
// manera segura.

//builder.Services.AddSingleton<Cache<UserDto>>();
//builder.Services.AddSingleton<Cache<GameDto>>();

//builder.Services.AddSqlServer<SteamContext>(builder.Configuration.GetConnectionString("Database"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
