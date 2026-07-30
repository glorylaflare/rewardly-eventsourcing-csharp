using Rewardly.Infra.Config;

namespace Rewardly.Api.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplication();
        services.AddInfrastructure();

        services.Configure<MongoDbettings>(configuration.GetSection("MongoDbSettings"));

        return services;
    }
}
