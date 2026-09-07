namespace Rewardly.Application.Queries.v1.GetBalance;

public sealed record GetBalanceResponse(Guid UserId, int Balance);