namespace Rewardly.Application.Requests;

public sealed record DebitPointsRequest(Guid AggregateId, int Points, string Reason);
