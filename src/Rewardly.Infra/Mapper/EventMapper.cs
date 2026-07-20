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
}
