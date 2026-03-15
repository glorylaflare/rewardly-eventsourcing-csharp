using Rewardly.Domain.Interfaces.v1;
using System.Reflection;

namespace Rewardly.Domain.Abstractions;

public abstract class AggregateRoot : IAggregateRoot
{
    private readonly List<IEvent> _uncommittedEvents = new();
    private static readonly Dictionary<Type, Dictionary<Type, MethodInfo>> _applyMethodsCache = new();

    public Guid Id { get; protected set; }
    public int Version { get; private set; }

    public IReadOnlyCollection<IEvent> GetUncommittedEvents()
        => _uncommittedEvents.AsReadOnly();

    public void ClearUncommittedEvents()
        => _uncommittedEvents.Clear();

    protected void RaiseEvent(IEvent @event)
    {
        @event.Version = Version + 1;
        ApplyEvent(@event);
        _uncommittedEvents.Add(@event);
        Version = @event.Version;
    }

    public void LoadFromHistory(IEnumerable<IEvent> events)
    {
        foreach (var @event in events)
        {
            ApplyEvent(@event);
            Version = @event.Version;
        }
    }

    private void ApplyEvent(IEvent @event)
    {
        var aggregateType = GetType();

        if (!_applyMethodsCache.TryGetValue(aggregateType, out var methods))
        {
            methods = aggregateType
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(m => m.Name == "Apply" && m.GetParameters().Length == 1)
                .ToDictionary(
                    m => m.GetParameters()[0].ParameterType,
                    m => m
                );
            
            _applyMethodsCache[aggregateType] = methods;
        }

        if (methods.TryGetValue(@event.GetType(), out var method))
        {
            method.Invoke(this, new object[] { @event });
        }
    }
}
