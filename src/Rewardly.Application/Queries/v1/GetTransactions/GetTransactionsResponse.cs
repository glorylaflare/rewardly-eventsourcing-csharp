namespace Rewardly.Application.Queries.v1.GetTransactions;

public sealed record GetTransactionsResponse(IReadOnlyCollection<TransactionResponse> Items, int Page, int PageSize, int TotalItems, int TotalPages);

public sealed record TransactionResponse(Guid Id, TransactionType Type, int Points, DateTime OccurredAt);