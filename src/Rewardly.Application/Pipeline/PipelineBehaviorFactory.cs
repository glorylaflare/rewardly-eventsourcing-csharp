namespace Rewardly.Application.Pipeline;

public class PipelineBehaviorFactory : IPipelineBehaviorFactory
{
    private readonly IServiceProvider _serviceProvider;
    private static readonly ConcurrentDictionary<Type, Type> _cache = new();

    public PipelineBehaviorFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IReadOnlyCollection<object> Create(IRequest request)
    {
        Type behaviorType = _cache.GetOrAdd(request.GetType(), static requestType =>
        {
            Type? responseType = requestType.GetInterfaces().Single(_ => _.IsGenericType && _.GetGenericTypeDefinition() == typeof(IRequest<>)).GetGenericArguments()[0];

            return typeof(IPipelineBehavior<,>).MakeGenericType(requestType, responseType);
        });

        return _serviceProvider.GetServices(behaviorType)
            .Cast<object>()
            .ToArray();
    }
}
