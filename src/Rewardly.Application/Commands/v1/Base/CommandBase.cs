using Rewardly.Application.Interfaces.Bus;

namespace Rewardly.Application.Commands.Base;

public abstract class CommandBase<TResponse> : ICommand<TResponse>
{
    public Guid CorrelationId => Guid.NewGuid();
    public DateTime CreatedAt => DateTime.UtcNow;
}
