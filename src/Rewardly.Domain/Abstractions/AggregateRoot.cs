using Rewardly.Domain.Interfaces.v1;
using System.Reflection;

namespace Rewardly.Domain.Abstractions;

public abstract class AggregateRoot : IAggregateRoot
{
    private readonly List<IEvent> _uncommittedEvents = new();

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
        var method = GetType().GetMethod(
            "Apply",
            BindingFlags.Instance | BindingFlags.NonPublic,
            null,
            new Type[] { @event.GetType() },
            null
        );

        method?.Invoke(this, new object[] { @event });
    }
}
