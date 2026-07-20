namespace Rewardly.Domain.DomainEvents.v1;

public sealed class PointsExpired : DomainEvent
{
    public int Points { get; }

    [JsonConstructor]
    public PointsExpired(Guid aggregateId, int points)
        : base(aggregateId)
    {
        Points = points;
    }
}
