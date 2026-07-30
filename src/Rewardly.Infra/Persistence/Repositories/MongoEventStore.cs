using MongoDB.Driver;
using Rewardly.Domain.Exceptions;
using Rewardly.Domain.Interfaces.v1;
using Rewardly.Infra.Mapper;

namespace Rewardly.Infra.Persistence.Repositories;

public class MongoEventStore : IEventStore
{
    private readonly IMongoCollection<EventDocument> _collection;

    public MongoEventStore(IMongoCollection<EventDocument> collection)
    {
        _collection = collection;
    }

    public async Task SaveAsync(Guid aggregateId, int expectedVersion, IEnumerable<IEvent> uncommittedEvents, CancellationToken cancellationToken)
    {
        List<EventDocument>? eventDocuments = uncommittedEvents.Select(EventMapper.ToDocument).ToList();

        if (eventDocuments.Count == 0)
        {
            return;
        }

        await EnsureExpectedVersion(
            aggregateId, 
            expectedVersion, 
            cancellationToken);

        await _collection.InsertManyAsync(
            eventDocuments, 
            cancellationToken: cancellationToken);
    }

    public async Task<IReadOnlyCollection<IEvent>> LoadAsync(Guid aggregateId, CancellationToken cancellationToken)
    {
        List<EventDocument>? documents = await _collection.Find(x => x.AggregateId == aggregateId)
            .SortBy(x => x.Version)
            .ToListAsync(cancellationToken);

        return documents.Select(EventMapper.ToDomainEvent)
            .ToList()
            .AsReadOnly();
    }

    private async Task EnsureExpectedVersion(Guid aggregateId, int expectedVersion, CancellationToken cancellationToken)
    {
        EventDocument? lastEvent = await _collection.Find(e => e.AggregateId == aggregateId)
            .SortByDescending(e => e.Version)
            .FirstOrDefaultAsync(cancellationToken);

        if (lastEvent is null)
        {
            if (expectedVersion != 0)
                throw new ConcurrencyException(aggregateId, expectedVersion, 0);

            return;
        }

        if (lastEvent.Version != expectedVersion)
        {
            throw new ConcurrencyException(aggregateId, expectedVersion, lastEvent.Version);
        }
    }
}
