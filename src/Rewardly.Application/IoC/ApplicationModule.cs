using Microsoft.Extensions.DependencyInjection;

namespace Rewardly.Application.IoC;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.Scan(s => s
        .FromAssemblies(typeof(ApplicationModule).Assembly)
        .AddClasses(c => c.Where(t => t.Name.EndsWith("Handler")))
        .AsImplementedInterfaces()
        .WithScopedLifetime());

        return services;
    }
}
