using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Rewardly.Application.Interfaces.Repositories.Read;
using Rewardly.Domain.Aggregates;
using Rewardly.Domain.Interfaces.v1;
using Rewardly.Infra.Config;
using Rewardly.Infra.Persistence;
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

        services.Configure<MongoDbSettings>(configuration.GetSection(MongoDbSettings.SectionName));
        AddMongoDriver(services);

        return services;
    }

    private static void AddMongoDriver(IServiceCollection services)
    {
        services.AddSingleton<IMongoClient>(serviceProvider =>
        {
            MongoDbSettings settings = serviceProvider
                .GetRequiredService<IOptions<MongoDbSettings>>()
                .Value;

            return new MongoClient(settings.ConnectionString);
        });

        services.AddSingleton(serviceProvider =>
        {
            IMongoClient client = serviceProvider.GetRequiredService<IMongoClient>();

            MongoDbSettings settings = serviceProvider
                .GetRequiredService<IOptions<MongoDbSettings>>()
                .Value;

            return client.GetDatabase(settings.DatabaseName);
        });

        services.AddSingleton(serviceProvider =>
        {
            IMongoDatabase database = serviceProvider.GetRequiredService<IMongoDatabase>();

            MongoDbSettings settings = serviceProvider
                .GetRequiredService<IOptions<MongoDbSettings>>()
                .Value;

            return database.GetCollection<EventDocument>(settings.CollectionName);
        });
    }
}
