using MongoDB.Driver;
using Rewardly.Domain.Interfaces.v1;
using Rewardly.Infra.Mapper;

namespace Rewardly.Infra.Persistence.Repositories;

public class MongoEventStore : IEventStore
{
    private readonly IMongoCollection<EventDocument> _collection;

    public MongoEventStore(
        IMongoCollection<EventDocument> collection)
    {
        _collection = collection;
    }

    public async Task SaveAsync(IEnumerable<IEvent> events, CancellationToken cancellationToken)
    {
        List<EventDocument>? documents = events.Select(EventMapper.ToDocument)
            .ToList();

        await _collection.InsertManyAsync(
            documents, 
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
}
