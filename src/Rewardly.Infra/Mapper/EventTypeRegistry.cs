using Rewardly.Domain.DomainEvents.v1;
using Rewardly.Domain.Exceptions;

namespace Rewardly.Infra.Mapper;

public static class EventTypeRegistry
{
    private static readonly IReadOnlyDictionary<string, Type> _eventTypes;

    static EventTypeRegistry()
    {
        _eventTypes = typeof(DomainEvent)
            .Assembly
            .GetTypes()
            .Where(type => typeof(DomainEvent).IsAssignableFrom(type) && !type.IsAbstract)
            .ToDictionary(type => type.Name, type => type, StringComparer.Ordinal);
    }

    public static Type GetEventType(string eventType)
    { 
        if (_eventTypes.TryGetValue(eventType, out var type))
        {
            return type;
        }

        throw new InvalidEventTypeException($"Event '{eventType}' is not registered.");
    }
}
