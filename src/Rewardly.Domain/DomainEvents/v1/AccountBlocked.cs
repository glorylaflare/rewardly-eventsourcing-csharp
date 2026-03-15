namespace Rewardly.Domain.DomainEvents.v1;

public sealed class AccountBlocked : DomainEvent
{
    public string Reason { get; init; }

    public AccountBlocked(Guid aggregateId, string reason) 
        : base(aggregateId)
    {
        Reason = reason;
    }
}
