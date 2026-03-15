namespace Rewardly.Domain.Interfaces.v1;

public interface IEvent
{
    Guid AggregateId { get; }
    DateTime OccurredAt { get; }
    int Version { get; set; }
    Dictionary<string, object> Metadata { get; }
}
