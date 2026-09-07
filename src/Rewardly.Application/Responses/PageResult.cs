namespace Rewardly.Application.Responses;

public sealed record PagedResult<T>(IReadOnlyCollection<T> Items, int TotalItems);
