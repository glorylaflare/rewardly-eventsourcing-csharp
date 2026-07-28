using Rewardly.Application.Interfaces.Bus;

namespace Rewardly.Application.Commands.Base;

public abstract class Command : CommandBase, ICommand { }

public abstract class Command<TResponse> : CommandBase, ICommand<TResponse> { }

public abstract class CommandBase : ICommandBase
{
    public Guid CorrelationId { get; } = Guid.NewGuid();
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
}
