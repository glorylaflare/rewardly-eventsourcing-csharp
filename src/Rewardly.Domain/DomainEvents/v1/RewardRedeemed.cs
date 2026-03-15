namespace Rewardly.Domain.DomainEvents.v1;

public sealed class RewardRedeemed : DomainEvent
{
    public Guid RewardId { get; init; }
    public int PointsCost { get; init; }

    public RewardRedeemed(Guid aggregateId, Guid rewardId, int pointsCost) : base(aggregateId)
    {
        RewardId = rewardId;
        PointsCost = pointsCost;
    }
}
