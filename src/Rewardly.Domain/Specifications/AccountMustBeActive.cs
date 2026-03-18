using Rewardly.Domain.Aggregates;
using Rewardly.Domain.Enums;
using Rewardly.Domain.Interfaces.v1;

namespace Rewardly.Domain.Specifications;

public sealed class AccountMustBeActive : ISpecification<RewardlyAccount>
{
    public bool IsSatisfiedBy(RewardlyAccount account)
        => account.Status == AccountStatus.Active;
}
