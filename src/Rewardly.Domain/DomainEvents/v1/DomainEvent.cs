using Rewardly.Domain.Interfaces.v1;

namespace Rewardly.Domain.DomainEvents.v1;

public abstract class DomainEvent : IEvent
{
    public Guid AggregateId { get; protected set; }
    public DateTime OccurredAt { get; protected set; }
    public int Version { get; private set; }
    public IReadOnlyDictionary<string, object> Metadata { get; protected set; }

    protected DomainEvent(Guid aggregateId) 
    { 
        AggregateId = aggregateId;
        OccurredAt = DateTime.UtcNow;
        Metadata = new Dictionary<string, object>();
    }

    internal void SetVersion(int version)
    {
        Version = version;
    }
}
