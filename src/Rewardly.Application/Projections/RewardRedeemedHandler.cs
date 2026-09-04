namespace Rewardly.Application.Projections;

public class RewardRedeemedHandler : IProjectionHandler<RewardRedeemed>
{
    private readonly IRewardAccountRepository _accountRepository;
    private readonly IRewardTransactionRepository _transactionRepository;

    public RewardRedeemedHandler(IRewardTransactionRepository transactionRepository, IRewardAccountRepository accountRepository)
    {
        _transactionRepository = transactionRepository;
        _accountRepository = accountRepository;
    }

    public async Task HandlerAsync(RewardRedeemed @event, CancellationToken cancellationToken)
    {
        RewardAccount? account = await _accountRepository.FindAsync(@event.AggregateId, cancellationToken);

        if (account is null)
            return;

        account.UpdateBalance(@event.Points, @event.OccurredAt);

        RewardTransaction transaction = new RewardTransaction(@event.EventId, @event.AggregateId, TransactionType.Redemption, @event.Points, @event.OccurredAt);

        await _transactionRepository.AddAsync(transaction, cancellationToken);
    }
}
