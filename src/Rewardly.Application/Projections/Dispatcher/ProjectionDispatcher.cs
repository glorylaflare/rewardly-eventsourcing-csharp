namespace Rewardly.Application.Projections.Dispatcher;

public sealed class ProjectionDispatcher : IProjectionDispatcher
{
    private readonly IProjectionInvokerFactory _invokerFactory;

    public ProjectionDispatcher(IProjectionInvokerFactory invokerFactory)
    {
        _invokerFactory = invokerFactory;
    }

    public async Task DispatchAsync(IEnumerable<IEvent> events, CancellationToken cancellationToken)
    {
        foreach (IEvent @event in events)
        {
            IProjectionInvoker invoker = _invokerFactory.Create(@event.GetType());

            await invoker.InvokeAsync(@event, cancellationToken);
        }
    }
}
