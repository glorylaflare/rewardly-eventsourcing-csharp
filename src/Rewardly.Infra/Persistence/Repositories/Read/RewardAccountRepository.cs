using Rewardly.Application.Interfaces.Repositories.Read;
using Rewardly.Application.ReadModels;

namespace Rewardly.Infra.Persistence.Repositories.Read;

public class RewardAccountRepository : IRewardAccountRepository
{
    public Task AddAsync(RewardAccount account, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task FindAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(RewardAccount account, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
