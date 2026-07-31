namespace Rewardly.Application.Pipeline;

public class PipelineBehaviorFactory : IPipelineBehaviorFactory
{
    private readonly IServiceProvider _serviceProvider;
    private static readonly ConcurrentDictionary<Type, Type> _cache = new();

    public PipelineBehaviorFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IReadOnlyCollection<object> Create(ICommandBase command)
    {
        Type behaviorType = _cache.GetOrAdd(command.GetType(), static commandType =>
        {
            Type? responseType = commandType.GetInterfaces().Single(_ => _.IsGenericType && _.GetGenericTypeDefinition() == typeof(ICommand<>)).GetGenericArguments()[0];

            return typeof(IPipelineBehavior<,>).MakeGenericType(commandType, responseType);
        });

        return _serviceProvider.GetServices(behaviorType)
            .Cast<object>()
            .ToList()
            .AsReadOnly();
    }
}
