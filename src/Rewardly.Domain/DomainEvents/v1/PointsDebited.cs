namespace Rewardly.Domain.DomainEvents.v1;

public sealed class PointsDebited : DomainEvent
{
    public int Points { get; }
    public string Reason { get; }

    [JsonConstructor]
    public PointsDebited(Guid aggregateId, int points, string reason)
        : base(aggregateId)
    {
        if (string.IsNullOrWhiteSpace(reason))
            throw new DomainException("Debit reason is required", ValidationErrorCodes.InvalidRequest);

        Points = points;
        Reason = reason;
    }
}
