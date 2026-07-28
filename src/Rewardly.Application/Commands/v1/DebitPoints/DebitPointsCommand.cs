namespace Rewardly.Application.Commands.v1.DebitPoints;

public sealed record DebitPointsCommand(Guid AccountId, int Points, string Reason) : ICommand<bool>;
