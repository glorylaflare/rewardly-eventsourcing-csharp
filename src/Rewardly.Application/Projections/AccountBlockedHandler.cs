namespace Rewardly.Application.Projections;

public class AccountBlockedHandler : IProjectionHandler<AccountBlocked>
{
    private readonly IRewardAccountRepository _repository;

    public AccountBlockedHandler(IRewardAccountRepository repository)
    {
        _repository = repository;
    }

    public async Task HandlerAsync(AccountBlocked @event, CancellationToken cancellationToken)
    {
        RewardAccount? account = await _repository.FindAsync(@event.AggregateId, cancellationToken);

        if (account is null)
            return;

        account.SetBlockedAccount(@event.OccurredAt);
    }
}
