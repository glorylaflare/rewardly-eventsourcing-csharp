using Rewardly.Application.Commands.v1.RedeemReward;
using Rewardly.Application.Requests;

namespace Rewardly.Application.Mappers;

internal static class RedeemRewardMapper
{
    public static RedeemRewardRequest ToRequest(RedeemRewardCommand source)
        => new RedeemRewardRequest(source.AggregateId, source.RewardId, source.Points);
}
