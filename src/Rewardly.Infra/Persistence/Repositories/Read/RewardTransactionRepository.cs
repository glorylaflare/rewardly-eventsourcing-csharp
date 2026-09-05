using Dapper;
using Rewardly.Application.Interfaces.Repositories.Read;
using Rewardly.Application.ReadModels;
using Rewardly.Infra.Persistence.Connection;

namespace Rewardly.Infra.Persistence.Repositories.Read;

public class RewardTransactionRepository : IRewardTransactionRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public RewardTransactionRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task AddAsync(RewardTransaction transaction, CancellationToken cancellationToken)
    {
        const string sql = """
            INSERT INTO RewardTransactions (Id, AccountId, Type, Points, OccurredAt)
            VALUES (@Id, @AccountId, @Type, @Points, @OccurredAt);
            """;

        using var connection = _connectionFactory.CreateConnection();

        var command = new CommandDefinition(sql, transaction, cancellationToken: cancellationToken);

        await connection.ExecuteAsync(command);
    }
}
