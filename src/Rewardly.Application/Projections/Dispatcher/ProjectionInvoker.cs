namespace Rewardly.Application.Projections.Dispatcher;

public sealed class ProjectionInvoker<TEvent> : IProjectionInvoker
    where TEvent : IEvent
{
    private readonly IProjectionHandler<TEvent> _handler;

    public ProjectionInvoker(IProjectionHandler<TEvent> handler)
    {
        _handler = handler;
    }

    public Task InvokeAsync(IEvent @event, CancellationToken cancellationToken)
    {
        return _handler.HandleAsync((TEvent)@event, cancellationToken);
    }
}
