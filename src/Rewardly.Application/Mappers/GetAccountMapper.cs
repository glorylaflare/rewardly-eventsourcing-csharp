using Rewardly.Application.Queries.v1.GetAccount;

namespace Rewardly.Application.Mappers;

internal static class GetAccountMapper
{
    public static GetAccountResponse ToResponse(RewardAccount source)
        => new GetAccountResponse(
            source.Id,
            source.UserId,
            source.Balance,
            source.Status.ToString(),
            source.CreatedAt,
            source.UpdatedAt);
}
