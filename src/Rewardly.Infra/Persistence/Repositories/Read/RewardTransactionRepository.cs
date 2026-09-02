using Rewardly.Application.Interfaces.Repositories.Read;
using Rewardly.Application.ReadModels;

namespace Rewardly.Infra.Persistence.Repositories.Read;

public class RewardTransactionRepository : IRewardTransactionRepository
{
    public Task AddAsync(RewardTransaction transaction, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
