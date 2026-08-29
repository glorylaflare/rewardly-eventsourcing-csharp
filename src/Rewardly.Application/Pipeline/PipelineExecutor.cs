namespace Rewardly.Application.Pipeline;

public sealed class PipelineExecutor : IPipelineExecutor
{
    private readonly IRequestInvokerFactory _requestInvokerFactory;
    private readonly IPipelineBehaviorFactory _behaviorFactory;

    public PipelineExecutor(IRequestInvokerFactory requestInvokerFactory, IPipelineBehaviorFactory behaviorFactory)
    {
        _requestInvokerFactory = requestInvokerFactory;
        _behaviorFactory = behaviorFactory;
    }

    public async Task<TResponse> ExecuteAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken)
    {
        IRequestInvoker invoker = _requestInvokerFactory.Create(request);

        IEnumerable<object> behaviors = _behaviorFactory.Create(request).Reverse();

        RequestHandlerDelegate<TResponse> next = async () =>
        {
            object? result = await invoker.InvokeAsync(request, cancellationToken);
            return (TResponse)result!;
        };

        foreach (dynamic behavior in behaviors)
        {
            RequestHandlerDelegate<TResponse> current = next;

            next = () => behavior.HandleAsync((dynamic)request, current, cancellationToken);
        }

        return await next();
    }
}
