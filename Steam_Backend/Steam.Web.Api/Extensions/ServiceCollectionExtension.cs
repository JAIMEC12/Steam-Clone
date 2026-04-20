using Microsoft.AspNetCore.Mvc;
using Serilog;
using Steam.Domain.Database.SqlServer.Context;
using Steam.Domain.Interfaces.Repositories;
using Steam.Infrastructure.Persistence.SqlServer.Repositories;
using Steam.Web.Api.Middleware;
using SteamApplication.Helpers;
using SteamApplication.Interfaces.Servicie;
using SteamApplication.Servicios;
using SteamShared.Constants;

namespace Steam.Web.Api.Extensions
{
    ///
    public static class ServiceCollectionExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IGameService, GameService>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
        }

        public static void AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = (ErrorContext) =>
                {
                    var errors = ErrorContext.ModelState.Values.SelectMany(x => x.Errors.Select(x => x.ErrorMessage).ToList()).ToList();
                    var response = ResponseHelper.Create(
                        data: ValidationConstants.VALIDATION_MESSAGE,
                        errors: errors,
                        message: ValidationConstants.VALIDATION_MESSAGE
                        );
                    return new BadRequestObjectResult(response);
                };
            });
            services.AddOpenApi();
            services.AddSqlServer<SteamContext>(configuration.GetConnectionString("Database"));
            services.AddRepositories();
            services.AddServices();
            services.AddMiddlewares();
            AddLogging(services);
        }

        public static void AddMiddlewares(this IServiceCollection services)
        {
            services.AddScoped<ErrorHandlerMiddleware>();
        }

        public static void AddLogging(IServiceCollection services)
        {
            services.AddSerilog();
            Log.Logger = new LoggerConfiguration()
                //For Files 
                .WriteTo.File(Path.Combine(Directory.GetCurrentDirectory(), "logs", "log.txt"), rollingInterval: RollingInterval.Day)
                //For Console
                .WriteTo.Console()
                .CreateLogger();
        }

    }
}
