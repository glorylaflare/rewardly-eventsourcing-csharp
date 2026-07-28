namespace Rewardly.Application.Bus;

public class CommandBus : ICommandBus
{
    private readonly ICommandHandlerResolver _resolver;

    public CommandBus(ICommandHandlerResolver resolver)
    {
        _resolver = resolver;
    }

    public async Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken)
    {
        CommandExecutionContext? context = _resolver.Resolve(command);

        return await ((dynamic)context.Handler).HandleAsync((dynamic)command, cancellationToken);
    }
}
