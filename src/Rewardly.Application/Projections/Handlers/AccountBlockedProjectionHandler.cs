namespace Rewardly.Application.Projections.Handlers;

public class AccountBlockedProjectionHandler : IProjectionHandler<AccountBlocked>
{
    private readonly IRewardAccountRepository _repository;

    public AccountBlockedProjectionHandler(IRewardAccountRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(AccountBlocked @event, CancellationToken cancellationToken)
    {
        RewardAccount? account = await _repository.FindAsync(@event.AggregateId, cancellationToken);

        if (account is null)
            return;

        account.SetBlockedAccount(@event.OccurredAt);

        await _repository.UpdateAsync(account, cancellationToken);
    }
}
