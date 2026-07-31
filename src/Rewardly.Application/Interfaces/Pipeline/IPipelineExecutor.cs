namespace Rewardly.Application.Interfaces.Pipeline;

/// <summary>
/// 
/// </summary>
public interface IPipelineExecutor
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TResponse> ExecuteAsync<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken);
}
