using Rewardly.Domain.DomainEvents.v1;
using Rewardly.Domain.Interfaces.v1;
using Rewardly.Infra.Persistence;
using System.Text.Json;

namespace Rewardly.Infra.Mapper;

public static class EventMapper
{
    public static EventDocument ToDocument(IEvent @event)
    {
        var payload = JsonSerializer.Serialize(
            @event,
            @event.GetType(),
            JsonSerializerOptions.Default);

        return new EventDocument(
            eventId: @event.EventId,
            eventType: @event.GetType().Name,
            payload: payload,
            version: @event.Version,
            occurredAt: @event.OccurredAt,
            aggregateId: @event.AggregateId,
            metadata: @event.Metadata
        );
    }

    public static IEvent ToDomainEvent(EventDocument document)
    {
        var eventType = EventTypeRegistry.GetEventType(document.EventType);

        var domainEvent = JsonSerializer.Deserialize(document.Payload, eventType) as IEvent;

        if (domainEvent is null)
        {
            throw new InvalidOperationException($"Unable to deserialize event '{document.EventType}'.");
        }

        if (domainEvent is DomainEvent e)
        {
            e.RestoreState(
                document.EventId, 
                document.AggregateId, 
                document.OccurredAt, 
                document.Version, 
                document.Metadata);
        }

        return domainEvent;
    }
}
