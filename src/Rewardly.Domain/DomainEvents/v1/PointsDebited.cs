using Rewardly.Domain.Exceptions;

namespace Rewardly.Domain.DomainEvents.v1;

public sealed class PointsDebited : DomainEvent
{
    public int Points { get; init; }
    public string Reason { get; init; }

    public PointsDebited(Guid aggregateId, int points, string reason)
        : base(aggregateId)
    {
        if (string.IsNullOrWhiteSpace(reason))
            throw new DomainException("Debit reason is required");

        Points = points;
        Reason = reason;
    }
}
