using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rewardly.Application.Interfaces.Repositories.Read;
using Rewardly.Domain.Aggregates;
using Rewardly.Domain.Interfaces.v1;
using Rewardly.Infra.Config;
using Rewardly.Infra.Persistence.Connection;
using Rewardly.Infra.Persistence.Repositories.Read;
using Rewardly.Infra.Persistence.Repositories.Write;

namespace Rewardly.Infra.IoC;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IEventStore, MongoEventStore>();
        services.AddScoped<IRepository<RewardlyAccount>, RewardlyAccountRepository>();

        services.AddSingleton<IDbConnectionFactory, SqlConnectionFactory>();  
        services.AddScoped<IRewardAccountRepository, RewardAccountRepository>();
        services.AddScoped<IRewardTransactionRepository, RewardTransactionRepository>();

        services.Configure<MongoDbettings>(configuration.GetSection("MongoDbSettings"));

        return services;
    }
}
