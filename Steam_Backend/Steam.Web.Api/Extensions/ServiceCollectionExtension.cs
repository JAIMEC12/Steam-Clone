using Steam.Domain.Database.SqlServer.Context;
using Steam.Domain.Interfaces.Repositories;
using Steam.Infrastructure.Persistence.SqlServer.Repositories;
using Steam.Web.Api.Middleware;
using SteamApplication.Interfaces.Servicie;
using SteamApplication.Servicios;

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
            services.AddControllers();
            services.AddOpenApi();
            services.AddSqlServer<SteamContext>(configuration.GetConnectionString("Database"));
            services.AddRepositories();
            services.AddServices();
            services.AddMiddlewares();
        }

        public static void AddMiddlewares(this IServiceCollection services)
        {
            services.AddScoped<ErrorHandlerMiddleware>();
        }

    }
}
