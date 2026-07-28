namespace Rewardly.Application.Commands.v1.CreditPoints;

public sealed record CreditPointsCommand(Guid AccountId, int Points, string Reason) : ICommand<bool>;