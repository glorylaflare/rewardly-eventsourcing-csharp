namespace Rewardly.Domain.Interfaces.v1;

public interface IEventStore
{
    Task SaveAsync(
        Guid aggregateId,
        int expectedVerion,
        IEnumerable<IEvent> uncommittedEvents,
        CancellationToken cancellationToken);
    
    Task<IReadOnlyCollection<IEvent>> LoadAsync(
        Guid aggregateId, 
        CancellationToken cancellationToken);
}
