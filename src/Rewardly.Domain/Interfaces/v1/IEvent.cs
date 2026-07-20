namespace Rewardly.Domain.Interfaces.v1;

public interface IEvent
{
    Guid EventId { get; }
    Guid AggregateId { get; }
    DateTime OccurredAt { get; }
    int Version { get; }
    IReadOnlyDictionary<string, object> Metadata { get; }
}
