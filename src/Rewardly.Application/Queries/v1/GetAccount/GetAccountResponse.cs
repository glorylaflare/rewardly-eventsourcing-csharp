namespace Rewardly.Application.Queries.v1.GetAccount;

public sealed record GetAccountResponse(Guid Id, Guid UserId, int Balance, string Status, DateTime CreatedAt, DateTime UpdatedAt);
