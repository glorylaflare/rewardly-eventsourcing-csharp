using Rewardly.Domain.Interfaces.v1;

namespace Rewardly.Domain.DomainEvents.v1;

public abstract class DomainEvent : IEvent
{
    public Guid AggregateId { get; protected set; }
    public DateTime OccurredAt { get; protected set; }
    public int Version { get; set; }

    protected DomainEvent(Guid aggregateId) 
    { 
        AggregateId = aggregateId;
        OccurredAt = DateTime.UtcNow;
    }
}
