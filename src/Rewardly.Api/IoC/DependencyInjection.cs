using Rewardly.Api.Handlers;
using Rewardly.Api.Mapper;
using Rewardly.Infra.Config;

namespace Rewardly.Api.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplication();
        services.AddInfrastructure();
        services.AddExceptionHandler<GlobalExceptionHandler>();

        services.AddScoped<IExceptionMapper, ExceptionMapper>();

        services.Configure<MongoDbettings>(configuration.GetSection("MongoDbSettings"));

        return services;
    }
}
