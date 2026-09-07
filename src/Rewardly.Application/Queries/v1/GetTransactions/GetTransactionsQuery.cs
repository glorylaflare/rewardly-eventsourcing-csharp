using Rewardly.Application.Interfaces.Bus.Query;

namespace Rewardly.Application.Queries.v1.GetTransactions;

public sealed record GetTransactionsQuery(Guid UserId, int Page, int PageSize) : IQuery<GetTransactionsResponse>;
