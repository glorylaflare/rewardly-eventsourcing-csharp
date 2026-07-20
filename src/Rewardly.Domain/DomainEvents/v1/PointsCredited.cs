namespace Rewardly.Domain.DomainEvents.v1;

public sealed class PointsCredited : DomainEvent
{
    public int Points { get; }
    public string Reason { get; }

    [JsonConstructor]
    public PointsCredited(Guid aggregateId, int points, string? reason) 
        : base(aggregateId)
    {
        Points = points;
        Reason = reason ?? "No reason";
    }
}
