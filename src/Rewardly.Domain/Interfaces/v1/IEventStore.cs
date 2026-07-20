namespace Rewardly.Domain.Interfaces.v1;

public interface IEventStore
{
    Task SaveAsync(IEnumerable<IEvent> events, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<IEvent>> LoadAsync(Guid aggregateId, CancellationToken cancellationToken);
}
