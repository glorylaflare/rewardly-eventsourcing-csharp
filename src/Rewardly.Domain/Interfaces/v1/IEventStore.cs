namespace Rewardly.Domain.Interfaces.v1;

public interface IEventStore
{
    Task SaveEventAsync(Guid aggregateId, IEnumerable<IEvent> events);
    Task<IEnumerable<IEvent>> GetEventsAsync(Guid aggregateId);
}
