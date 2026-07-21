namespace Rewardly.Api.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        services.AddApplication();
        services.AddInfrastructure();

        return services;
    }
}
