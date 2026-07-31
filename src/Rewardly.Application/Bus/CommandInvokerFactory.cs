namespace Rewardly.Application.Bus;

public sealed class CommandInvokerFactory : ICommandInvokerFactory
{
    private readonly IServiceProvider _serviceProvider;
    private static readonly ConcurrentDictionary<Type, Type> _cache = new();

    public CommandInvokerFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public ICommandInvoker Create(ICommandBase command)
    {
        Type invokerType = _cache.GetOrAdd(command.GetType(), static commandType =>
        {
            Type? responseType = commandType.GetInterfaces().Single(_ => _.IsGenericType && _.GetGenericTypeDefinition() == typeof(ICommand<>)).GetGenericArguments()[0];

            return typeof(CommandInvoker<,>).MakeGenericType(commandType, responseType);
        });

        return (ICommandInvoker)_serviceProvider.GetRequiredService(invokerType);
    }
}
