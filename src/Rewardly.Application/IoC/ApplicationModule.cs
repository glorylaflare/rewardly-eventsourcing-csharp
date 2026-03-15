using Microsoft.Extensions.DependencyInjection;

namespace Rewardly.Application.IoC;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.Scan(s => s
        .FromAssemblies((IEnumerable<System.Reflection.Assembly>)typeof(ApplicationModule))
        .AddClasses(c => c.Where(t => t.Name.EndsWith("Handler")))
        .AsImplementedInterfaces()
        .WithScopedLifetime());

        return services;
    }
}
