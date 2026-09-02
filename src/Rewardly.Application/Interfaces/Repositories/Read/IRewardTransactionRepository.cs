namespace Rewardly.Application.Interfaces.Repositories.Read;

/// <summary>
/// 
/// </summary>
public interface IRewardTransactionRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="transaction"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task AddAsync(RewardTransaction transaction, CancellationToken cancellationToken);
}
