namespace Rewardly.Application.Requests;

public sealed record CreditPointsRequest(Guid AggregateId, int Points, string Reason);
