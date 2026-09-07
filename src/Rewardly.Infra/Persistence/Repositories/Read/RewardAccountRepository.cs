using Dapper;
using Rewardly.Application.Interfaces.Repositories.Read;
using Rewardly.Application.ReadModels;
using Rewardly.Infra.Persistence.Connection;

namespace Rewardly.Infra.Persistence.Repositories.Read;

public class RewardAccountRepository : IRewardAccountRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public RewardAccountRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task AddAsync(RewardAccount account, CancellationToken cancellationToken)
    {
        const string sql = """
            INSERT INTO RewardAccounts (Id, UserId, Balance, Status, CreatedAt, UpdatedAt)
            VALUES (@Id, @UserId, @Balance, @Status, @CreatedAt, @UpdatedAt);
            """;

        using var connection = _connectionFactory.CreateConnection();

        var command = new CommandDefinition(sql, account, cancellationToken: cancellationToken);

        await connection.ExecuteAsync(command);
    }

    public async Task<RewardAccount?> FindAsync(Guid userId, CancellationToken cancellationToken)
    {
        const string sql = """
            SELECT * FROM RewardAccounts
            WHERE UserId = @UserId;
            """;

        using var connection = _connectionFactory.CreateConnection();

        var command = new CommandDefinition(sql, new { UserId = userId }, cancellationToken: cancellationToken);

        return await connection.QuerySingleOrDefaultAsync<RewardAccount>(command);
    }

    public async Task UpdateAsync(RewardAccount account, CancellationToken cancellationToken)
    {
        const string sql = """
            UPDATE RewardAccounts
            SET Balance = @Balance, Status = @Status, UpdatedAt = @UpdatedAt
            WHERE UserId = @UserId;
            """;

        using var connection = _connectionFactory.CreateConnection();

        var command = new CommandDefinition(sql, account, cancellationToken: cancellationToken);

        await connection.ExecuteAsync(command);
    }
}
