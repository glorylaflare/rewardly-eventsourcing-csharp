namespace Rewardly.Domain.DomainEvents.v1;

public sealed class AccountCancelled : DomainEvent
{
    public string Reason { get; init; }

    public AccountCancelled(Guid aggregateId, string reason) 
        : base(aggregateId)
    {
        Reason = reason;
    }
}
