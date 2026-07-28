using Rewardly.Application.Interfaces.Bus;

namespace Rewardly.Application.Commands.Base;

public abstract class CommandBase<TResponse> : ICommand<TResponse>
{
    public Guid CorrelationId { get; } = Guid.NewGuid();
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
}
