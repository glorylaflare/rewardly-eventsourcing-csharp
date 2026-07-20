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
        var documents = events.Select(EventMapper.ToDocument).ToList();

        await _collection.InsertManyAsync(
            documents, 
            cancellationToken: cancellationToken);
    }

    public Task<IReadOnlyCollection<IEvent>> LoadAsync(Guid aggregateId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException("MongoDB LoadAsync implementation needed");
    }
}
