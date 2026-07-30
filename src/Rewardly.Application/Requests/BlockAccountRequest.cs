namespace Rewardly.Application.Requests;

public sealed record BlockAccountRequest(Guid AggregateId, string Reason);
