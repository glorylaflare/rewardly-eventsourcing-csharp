namespace Rewardly.Domain.DomainEvents.v1;

public sealed class RewardRedeemed : DomainEvent
{
    public Guid RewardId { get; }
    public int Points { get; }

    [JsonConstructor]
    public RewardRedeemed(Guid aggregateId, Guid rewardId, int points) 
        : base(aggregateId)
    {
        RewardId = rewardId;
        Points = points;
    }
}
