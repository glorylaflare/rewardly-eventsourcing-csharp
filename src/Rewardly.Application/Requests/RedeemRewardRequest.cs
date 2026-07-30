namespace Rewardly.Application.Requests;

public sealed record RedeemRewardRequest(Guid AggregateId, Guid RewardId, int Points);
