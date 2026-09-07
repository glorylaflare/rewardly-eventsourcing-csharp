using Rewardly.Application.Queries.v1.GetBalance;

namespace Rewardly.Application.Mappers;

internal static class GetBalanceMapper
{
    public static GetBalanceResponse ToResponse(RewardAccount source)
        => new GetBalanceResponse(source.UserId, source.Balance);
}
