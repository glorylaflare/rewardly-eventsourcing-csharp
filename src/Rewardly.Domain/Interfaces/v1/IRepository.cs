namespace Rewardly.Domain.Interfaces.v1;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity> GetById(Guid id);
    Task SaveAsync(TEntity entity);
}
