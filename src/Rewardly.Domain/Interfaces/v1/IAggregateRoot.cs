namespace Rewardly.Domain.Interfaces.v1;

public interface IAggregateRoot
{
    Guid Id { get; }
    int Version { get; }

    IReadOnlyCollection<IEvent> GetUncommittedEvents();
    void ClearUncommittedEvents();
    void LoadFromHistory(IEnumerable<IEvent> events);
}
