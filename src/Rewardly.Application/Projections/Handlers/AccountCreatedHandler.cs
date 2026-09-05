using Rewardly.Domain.Enums;

namespace Rewardly.Application.Projections.Handlers;

public class AccountCreatedHandler : IProjectionHandler<AccountCreated>
{
    private readonly IRewardAccountRepository _repository;

    public AccountCreatedHandler(IRewardAccountRepository repository)
    {
        _repository = repository;
    }

    private const int INITIAL_BALANCE = 0;

    public async Task HandleAsync(AccountCreated @event, CancellationToken cancellationToken)
    {
        RewardAccount? account = new RewardAccount(@event.AggregateId, @event.UserId, INITIAL_BALANCE, AccountStatus.Active, @event.OccurredAt);

        await _repository.AddAsync(account, cancellationToken);
    }
}
