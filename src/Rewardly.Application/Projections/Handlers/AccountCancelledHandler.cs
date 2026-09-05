namespace Rewardly.Application.Projections.Handlers;

public class AccountCancelledHandler : IProjectionHandler<AccountCancelled>
{
    private readonly IRewardAccountRepository _repository;

    public AccountCancelledHandler(IRewardAccountRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(AccountCancelled @event, CancellationToken cancellationToken)
    {
        RewardAccount? account = await _repository.FindAsync(@event.AggregateId, cancellationToken);

        if (account is null)
            return;

        account.SetCancelledAccount(@event.OccurredAt);
    }
}
