using Rewardly.Domain.Aggregates;
using Rewardly.Domain.Interfaces.v1;

namespace Rewardly.Infra.Persistence.Repositories;

public sealed class RewardlyAccountRepository : IRepository<RewardlyAccount>
{
    private readonly IEventStore _eventStore;

    public RewardlyAccountRepository(IEventStore eventStore)
    {
        _eventStore = eventStore;
    }

    public async Task<RewardlyAccount> FindOneAsync(Guid id, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<IEvent>? events = await _eventStore.LoadAsync(
            aggregateId: id, 
            cancellationToken);

        if (!events.Any())
        {
            throw new AggregateException($"RewardlyAccount '{id}' not found.");
        }

        return RewardlyAccount.FromHistory(events);
    }

    public async Task SaveAsync(RewardlyAccount account, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<IEvent>? uncommittedEvents = account.GetUncommittedEvents();

        if (uncommittedEvents.Count == 0)
        {
            return;
        }

        int expectedVersion = account.Version - uncommittedEvents.Count;

        await _eventStore.SaveAsync(
            aggregateId: account.Id, 
            expectedVersion, 
            uncommittedEvents, 
            cancellationToken);

        account.ClearUncommittedEvents();
    }
}
