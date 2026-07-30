using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Rewardly.Domain.Aggregates;
using Rewardly.Domain.Interfaces.v1;
using Rewardly.Infra.Persistence.Repositories;

namespace Rewardly.Infra.IoC;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IEventStore, MongoEventStore>();
        services.AddScoped<IRepository<RewardlyAccount>, RewardlyAccountRepository>();

        return services;
    }
}
