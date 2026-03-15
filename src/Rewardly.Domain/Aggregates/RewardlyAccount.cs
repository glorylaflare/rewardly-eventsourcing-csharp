using Rewardly.Domain.Abstractions;
using Rewardly.Domain.DomainEvents.v1;
using Rewardly.Domain.Enums;

namespace Rewardly.Domain.Aggregates;

public sealed class RewardlyAccount : AggregateRoot
{
    public Guid UserId { get; private set; }
    public int Balance { get; private set; }
    public AccountStatus Status { get; private set; }

    private RewardlyAccount() { }

    public static RewardlyAccount Create(Guid accountId, Guid userId)
    {
        var account = new RewardlyAccount();
        account.RaiseEvent(new AccountCreated(accountId, userId));

        return account;
    }
}
