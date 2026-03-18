using Rewardly.Domain.Exceptions;

namespace Rewardly.Domain.DomainEvents.v1;

public sealed class RewardRedeemed : DomainEvent
{
    public Guid RewardId { get; init; }
    public int Points { get; init; }

    public RewardRedeemed(Guid aggregateId, Guid rewardId, int points) : base(aggregateId)
    {
        RewardId = rewardId;
        Points = points;
    }
}
