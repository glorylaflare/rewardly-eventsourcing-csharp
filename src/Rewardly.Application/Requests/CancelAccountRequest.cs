namespace Rewardly.Application.Requests;

public sealed record CancelAccountRequest(Guid AggregateId, string Reason);
