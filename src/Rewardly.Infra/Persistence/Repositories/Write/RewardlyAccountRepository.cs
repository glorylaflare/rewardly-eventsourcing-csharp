using Rewardly.Domain.Aggregates;
using Rewardly.Domain.Interfaces.v1;

namespace Rewardly.Infra.Persistence.Repositories.Write;

public sealed class RewardlyAccountRepository : IRepository<RewardlyAccount>
{
    private readonly IEventStore _eventStore;

    public RewardlyAccountRepository(IEventStore eventStore)
    {
        _eventStore = eventStore;
    }

    public async Task<RewardlyAccount> FindOneAsync(Guid aggregateId, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<IEvent>? events = await _eventStore.LoadAsync(
            aggregateId: aggregateId, 
            cancellationToken);

        if (!events.Any())
        {
            throw new AggregateException($"RewardlyAccount '{aggregateId}' not found.");
        }

        return RewardlyAccount.FromHistory(events);
    }

    public async Task SaveAsync(RewardlyAccount aggregate, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<IEvent>? uncommittedEvents = aggregate.GetUncommittedEvents();

        if (uncommittedEvents.Count == 0)
        {
            return;
        }

        int expectedVersion = aggregate.Version - uncommittedEvents.Count;

        await _eventStore.SaveAsync(
            aggregateId: aggregate.Id, 
            expectedVersion, 
            uncommittedEvents, 
            cancellationToken);

        aggregate.ClearUncommittedEvents();
    }
}
