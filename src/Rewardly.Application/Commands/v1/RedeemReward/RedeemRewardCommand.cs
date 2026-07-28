namespace Rewardly.Application.Commands.v1.RedeemReward;

public sealed record RedeemRewardCommand(Guid AccountId, Guid RewardId, int Points) : ICommand<bool>;
