using Microsoft.Extensions.DependencyInjection;

namespace Rewardly.Application.Bus;

public sealed class CommandInvokerFactory : ICommandInvokerFactory
{
    private readonly IServiceProvider _serviceProvider;

    public CommandInvokerFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public ICommandInvoker Create(ICommandBase command)
    {
        Type? commandType = command.GetType();

        Type? responseType = commandType.GetInterfaces()
            .First(_ => _.IsGenericType && _.GetGenericTypeDefinition() == typeof(ICommand<>))
            .GetGenericArguments()[0];

        Type? invokerType = typeof(CommandInvoker<,>).MakeGenericType(commandType, responseType);

        return (ICommandInvoker)_serviceProvider.GetRequiredService(invokerType);
    }
}