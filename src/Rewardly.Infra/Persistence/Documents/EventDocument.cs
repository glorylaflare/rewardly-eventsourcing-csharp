namespace Rewardly.Infra.Persistence;

public sealed class EventDocument
{
    public Guid EventId { get; private set; }
    public string EventType { get; private set; }
    public string Payload { get; private set; }
    public int Version { get; private set; }
    public DateTime OccurredAt { get; private set; }
    public Guid AggregateId { get; private set; }
    public IReadOnlyDictionary<string, object> Metadata { get; private set; }

    public EventDocument(
        Guid eventId,
        string eventType, 
        string payload, 
        int version,
        DateTime occurredAt,
        Guid aggregateId, 
        IReadOnlyDictionary<string, object> metadata)
    {
        EventId = eventId;
        EventType = eventType;
        Payload = payload;
        Version = version;
        OccurredAt = occurredAt;
        AggregateId = aggregateId;
        Metadata = metadata;
    }
}
