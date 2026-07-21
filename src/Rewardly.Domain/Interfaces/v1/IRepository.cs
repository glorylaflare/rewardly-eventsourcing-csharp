namespace Rewardly.Domain.Interfaces.v1;

public interface IRepository<TAggregate> where TAggregate : IAggregateRoot
{
    Task<TAggregate> FindOneAsync(Guid id, CancellationToken cancellationToken);
    Task SaveAsync(TAggregate account, CancellationToken cancellationToken);
}
