namespace Rewardly.Domain.Interfaces.v1;

public interface ISpecification<T>
{
    bool IsSatisfiedBy(T item);
}
