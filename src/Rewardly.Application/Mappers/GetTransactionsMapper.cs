using Rewardly.Application.Queries.v1.GetTransactions;

namespace Rewardly.Application.Mappers;

internal static class GetTransactionsMapper
{
    public static IReadOnlyCollection<TransactionResponse> ToItems(IReadOnlyCollection<RewardTransaction> items)
        => items.Select(item => new TransactionResponse(item.AccountId, item.Type, item.Points, item.OccurredAt)).ToArray();

    internal static GetTransactionsResponse ToResponse(IReadOnlyCollection<TransactionResponse> items, int page, int pageSize, int totalItems, int totalPages)
        => new GetTransactionsResponse(items, page, pageSize, totalItems, totalPages);
}
