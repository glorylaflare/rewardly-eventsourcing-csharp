using Microsoft.Extensions.DependencyInjection;
using Rewardly.Domain.Interfaces.v1;

namespace Rewardly.Infra.IoC;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IEventStore, EventStore>();
        services.AddScoped<IRepository<>, Repository>();

        return services;
    }
}
