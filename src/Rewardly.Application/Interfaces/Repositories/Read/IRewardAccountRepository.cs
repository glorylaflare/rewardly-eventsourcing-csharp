namespace Rewardly.Application.Interfaces.Repositories.Read;

/// <summary>
/// 
/// </summary>
public interface IRewardAccountRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="account"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task AddAsync(RewardAccount account, CancellationToken cancellationToken);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<RewardAccount?> FindAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="account"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task UpdateAsync(RewardAccount account, CancellationToken cancellationToken);
}
