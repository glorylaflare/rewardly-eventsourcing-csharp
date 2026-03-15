namespace Rewardly.Domain.Interfaces.v1;

public interface IRepository<TAggregate> where TAggregate : IAggregateRoot
{
    Task<TAggregate> GetById(Guid id);
    Task SaveAsync(TAggregate entity);
}
