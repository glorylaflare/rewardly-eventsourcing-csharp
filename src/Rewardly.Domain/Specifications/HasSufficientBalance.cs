using Rewardly.Domain.Aggregates;
using Rewardly.Domain.Interfaces.v1;

namespace Rewardly.Domain.Specifications;

public sealed class HasSufficientBalance : ISpecification<RewardlyAccount>
{
    private readonly int _points;

    public HasSufficientBalance(int points)
    {
        _points = points;
    }

    public bool IsSatisfiedBy(RewardlyAccount account)
        => account.Balance.Value >= _points;
}
