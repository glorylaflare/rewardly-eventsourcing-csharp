namespace Rewardly.Application.Bus;

public sealed class RequestInvokerFactory : IRequestInvokerFactory
{
    private readonly IServiceProvider _serviceProvider;
    private static readonly ConcurrentDictionary<Type, Type> _cache = new();

    public RequestInvokerFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IRequestInvoker Create(IRequest request)
    {
        Type invokerType = _cache.GetOrAdd(request.GetType(), static requestType =>
        {
            Type? responseType = requestType.GetInterfaces().Single(_ => _.IsGenericType && _.GetGenericTypeDefinition() == typeof(IRequest<>)).GetGenericArguments()[0];

            return typeof(RequestInvoker<,>).MakeGenericType(requestType, responseType);
        });

        return (IRequestInvoker)_serviceProvider.GetRequiredService(invokerType);
    }
}
