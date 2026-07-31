using Microsoft.Extensions.DependencyInjection;
using Rewardly.Application.Interfaces.Pipeline;

namespace Rewardly.Application.Pipeline;

public sealed class PipelineExecutor : IPipelineExecutor
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ICommandInvokerFactory _commandInvokerFactory;

    public PipelineExecutor(IServiceProvider serviceProvider, ICommandInvokerFactory commandInvokerFactory)
    {
        _serviceProvider = serviceProvider;
        _commandInvokerFactory = commandInvokerFactory;
    }

    public async Task<TResponse> ExecuteAsync<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken)
    {
        ICommandInvoker? invoker = _commandInvokerFactory.Create(command);

        RequestHandlerDelegate<TResponse> next = async () =>
        {
            object? resut = await invoker.InvokeAsync(command, cancellationToken);
            return (TResponse)resut;
        };

        var behaviors = _serviceProvider.GetServices<IPipelineBehavior<ICommand<TResponse>, TResponse>>().Reverse().ToList();

        foreach (var behavior in behaviors)
        {
            var current = next;

            next = () => behavior.HandleAsync(command, current, cancellationToken);
        }

        return await next();
    }
}
