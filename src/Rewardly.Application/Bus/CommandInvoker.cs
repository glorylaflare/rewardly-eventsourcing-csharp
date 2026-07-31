namespace Rewardly.Application.Bus;

public sealed class CommandInvoker<TCommand, TResponse> : ICommandInvoker
    where TCommand : ICommand<TResponse>
{
    private readonly ICommandHandler<TCommand, TResponse> _handler;

    public CommandInvoker(ICommandHandler<TCommand, TResponse> handler)
    {
        _handler = handler;
    }

    public async Task<object?> InvokeAsync(ICommandBase command, CancellationToken cancellationToken)
    {
        return await _handler.HandleAsync((TCommand)command, cancellationToken);
    }
}
