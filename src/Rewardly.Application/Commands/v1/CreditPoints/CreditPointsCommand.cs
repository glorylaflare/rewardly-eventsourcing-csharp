namespace Rewardly.Application.Commands.v1.CreditPoints;

public sealed record CreditPointsCommand(Guid AggregateId, int Points, string Reason) : ICommand<bool>;
