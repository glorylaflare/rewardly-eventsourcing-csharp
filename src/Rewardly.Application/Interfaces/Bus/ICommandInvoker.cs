namespace Rewardly.Application.Interfaces.Bus;

/// <summary>
/// 
/// </summary>
public interface ICommandInvoker
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<object?> InvokeAsync(ICommandBase command, CancellationToken cancellationToken);
}