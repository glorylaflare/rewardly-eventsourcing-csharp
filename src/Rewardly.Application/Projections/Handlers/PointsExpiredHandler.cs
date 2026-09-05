namespace Rewardly.Application.Projections.Handlers;

public class PointsExpiredHandler : IProjectionHandler<PointsExpired>
{
    private readonly IRewardAccountRepository _accountRepository;
    private readonly IRewardTransactionRepository _transactionRepository;

    public PointsExpiredHandler(IRewardAccountRepository accountRepository, IRewardTransactionRepository transactionRepository)
    {
        _accountRepository = accountRepository;
        _transactionRepository = transactionRepository;
    }

    public async Task HandleAsync(PointsExpired @event, CancellationToken cancellationToken)
    {
        RewardAccount? account = await _accountRepository.FindAsync(@event.AggregateId, cancellationToken);

        if (account is null)
            return;

        account.UpdateBalance(@event.Points, @event.OccurredAt);

        RewardTransaction transaction = new RewardTransaction(@event.EventId, @event.AggregateId, TransactionType.Expiration, @event.Points, @event.OccurredAt);

        await _transactionRepository.AddAsync(transaction, cancellationToken);
    }
}
