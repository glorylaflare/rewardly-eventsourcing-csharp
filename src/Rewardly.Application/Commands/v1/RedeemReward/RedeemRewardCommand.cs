using Rewardly.Application.Interfaces.Bus.Command;

namespace Rewardly.Application.Commands.v1.RedeemReward;

public sealed record RedeemRewardCommand(Guid AggregateId, Guid RewardId, int Points) : ICommand<bool>;
