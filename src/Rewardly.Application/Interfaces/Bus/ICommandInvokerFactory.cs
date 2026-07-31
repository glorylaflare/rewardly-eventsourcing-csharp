namespace Rewardly.Application.Interfaces.Bus;

/// <summary>
/// 
/// </summary>
public interface ICommandInvokerFactory
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    ICommandInvoker Create(ICommandBase command);
}
