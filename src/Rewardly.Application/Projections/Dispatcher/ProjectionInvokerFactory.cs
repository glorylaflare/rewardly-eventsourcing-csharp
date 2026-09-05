namespace Rewardly.Application.Projections.Dispatcher;

public sealed class ProjectionInvokerFactory : IProjectionInvokerFactory
{
    private readonly IServiceProvider _serviceProvider;

    public ProjectionInvokerFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IProjectionInvoker Create(Type eventType)
    {
        Type invokerType = typeof(ProjectionInvoker<>).MakeGenericType(eventType);

        return (IProjectionInvoker)_serviceProvider.GetRequiredService(invokerType);
    }
}
