namespace Rewardly.Domain.DomainEvents.v1;

public sealed class AccountCreated : DomainEvent
{
    public Guid UserId { get; init; }

    public AccountCreated(Guid aggregateId, Guid userId) 
        : base(aggregateId)
    {
        UserId = userId;
    }
}
