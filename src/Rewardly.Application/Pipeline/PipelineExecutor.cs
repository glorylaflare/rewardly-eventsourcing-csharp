using Rewardly.Application.Abstractions;
using Rewardly.Application.Interfaces.Pipeline;

namespace Rewardly.Application.Pipeline;

public sealed class PipelineExecutor : IPipelineExecutor
{
    private readonly ICommandInvokerFactory _commandInvokerFactory;
    private readonly IPipelineBehaviorFactory _behaviorFactory;

    public PipelineExecutor(ICommandInvokerFactory commandInvokerFactory, IPipelineBehaviorFactory behaviorFactory)
    {
        _commandInvokerFactory = commandInvokerFactory;
        _behaviorFactory = behaviorFactory;
    }

    public async Task<TResponse> ExecuteAsync<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken)
    {
        ICommandInvoker? invoker = _commandInvokerFactory.Create(command);

        List<object> behaviors = _behaviorFactory.Create(command).Reverse().ToList();

        RequestHandlerDelegate<TResponse> next = async () =>
        {
            object? resut = await invoker.InvokeAsync(command, cancellationToken);
            return (TResponse)resut!;
        };

        foreach (dynamic behavior in behaviors)
        {
            RequestHandlerDelegate<TResponse> current = next;

            next = () => behavior.HandleAsync((dynamic)command, current, cancellationToken);
        }

        return await next();
    }
}
