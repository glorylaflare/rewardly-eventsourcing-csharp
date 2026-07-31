namespace Rewardly.Application.Abstractions;

/// <summary>
/// 
/// </summary>
public interface IPipelineBehaviorFactory
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    IReadOnlyCollection<object> Create(ICommandBase command);
}
