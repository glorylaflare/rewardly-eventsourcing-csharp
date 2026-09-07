using Rewardly.Application.Interfaces.Bus.Query;
using Rewardly.Application.Responses;
using Rewardly.Domain.Exceptions;

namespace Rewardly.Application.Queries.v1.GetTransactions;

public sealed class GetTransactionsQueryHandler : IQueryHandler<GetTransactionsQuery, GetTransactionsResponse>
{
    private readonly IRewardAccountRepository _accountRepository;
    private readonly IRewardTransactionRepository _transactionRepository;

    public GetTransactionsQueryHandler(IRewardAccountRepository accountRepository, IRewardTransactionRepository transactionRepository)
    {
        _accountRepository = accountRepository;
        _transactionRepository = transactionRepository;
    }

    public async Task<GetTransactionsResponse> HandleAsync(GetTransactionsQuery request, CancellationToken cancellationToken)
    {
        RewardAccount? account = await _accountRepository.FindAsync(request.UserId, cancellationToken);

        if (account is null)
            throw new AccountNotFoundException("Account projection was not found.");

        PagedResult<RewardTransaction> result = await _transactionRepository.FindAsync(account.Id, request.Page, request.PageSize, cancellationToken);

        IReadOnlyCollection<TransactionResponse> items = GetTransactionsMapper.ToItems(result.Items);

        int totalPages = (int)Math.Ceiling(result.TotalItems / (double)request.PageSize);

        return GetTransactionsMapper.ToResponse(items, request.Page, request.PageSize, result.TotalItems, totalPages);
    }
}
