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
        IReadOnlyCollection<IEvent>? events = await _eventStore.LoadAsync(id, cancellationToken);

        if (!events.Any())
        {
            throw new AggregateException($"RewardlyAccount '{id}' not found.");
        }

        return RewardlyAccount.FromHistory(events);
    }

    public async Task SaveAsync(RewardlyAccount account, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<IEvent>? events = account.GetUncommittedEvents();

        if (events.Count == 0)
        {
            return;
        }

        await _eventStore.SaveAsync(events, cancellationToken);

        account.ClearUncommittedEvents();
    }
}
