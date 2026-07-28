using Rewardly.Application.Interfaces.Bus;

namespace Rewardly.Application.Bus;

public class CommandHandlerResolver : ICommandHandlerResolver
{
    private readonly IServiceProvider _serviceProvider;

    public CommandHandlerResolver(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public CommandExecutionContext Resolve(ICommand command)
    {
        Type? handlerType = typeof(ICommandHandler<,>).MakeGenericType(command.GetType());

        return ResolveHandler(command, handlerType);
    }

    public CommandExecutionContext Resolve<TResponse>(ICommand<TResponse> command)
    {
        Type? handlerType = typeof(ICommandHandler<,>).MakeGenericType(command.GetType(), typeof(TResponse));

        return ResolveHandler(command, handlerType);
    }

    private CommandExecutionContext ResolveHandler(ICommandBase command, Type handlerType) 
    {
        object? handler = _serviceProvider.GetService(handlerType);

        if (handler is null)
            throw new InvalidOperationException($"No handler registered for '{handlerType.Name}'.");

        return new CommandExecutionContext(command, handler, command.GetType(), handlerType);
    }
}
