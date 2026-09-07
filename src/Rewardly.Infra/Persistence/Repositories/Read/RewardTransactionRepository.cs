using Dapper;
using Rewardly.Application.Interfaces.Repositories.Read;
using Rewardly.Application.ReadModels;
using Rewardly.Application.Responses;
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

    public async Task<PagedResult<RewardTransaction>> FindAsync(Guid accountId, int page, int pageSize, CancellationToken cancellationToken)
    {
        const string sql = """
            SELECT Id, AccountId, Type, Points, OccurredAt
            FROM RewardTransactions
            WHERE AccountId = @AccountId
            ORDER BY OccurredAt DESC
            OFFSET @Offset ROWS
            FETCH NEXT @PageSize ROWS ONLY;

            SELECT COUNT(*)
            FROM RewardTransactions
            WHERE AccountId = @AccountId;
            """;

        int offset = (page - 1) * pageSize;

        using var connection = _connectionFactory.CreateConnection();

        var command = new CommandDefinition(
            sql,
            new
            {
                AccountId = accountId,
                Offset = offset,
                PageSize = pageSize
            },
            cancellationToken: cancellationToken);

        using var result = await connection.QueryMultipleAsync(command);

        IReadOnlyCollection<RewardTransaction> transactions = (await result.ReadAsync<RewardTransaction>()).ToList();

        int totalItems = await result.ReadSingleAsync<int>();

        return new PagedResult<RewardTransaction>(transactions, totalItems);
    }
}
