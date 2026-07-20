using Rewardly.Domain.Interfaces.v1;

namespace Rewardly.Domain.DomainEvents.v1;

public abstract class DomainEvent : IEvent
{
    public Guid EventId { get; private set; }
    public Guid AggregateId { get; private set; }
    public DateTime OccurredAt { get; private set; }
    public int Version { get; private set; }
    public IReadOnlyDictionary<string, object> Metadata { get; private set; }

    protected DomainEvent(Guid aggregateId) 
    {
        EventId = Guid.NewGuid();
        AggregateId = aggregateId;
        OccurredAt = DateTime.UtcNow;
        Metadata = new Dictionary<string, object>();
    }

    internal void SetVersion(int version)
    {
        Version = version;
    }

    internal void RestoreState(
        Guid eventId, 
        Guid aggregateId,
        DateTime occurredAt,
        int version, 
        IReadOnlyDictionary<string, object> metadata)
    {
        EventId = eventId;
        AggregateId = aggregateId;
        OccurredAt = occurredAt;
        Version = version;
        Metadata = metadata;
    }
}
