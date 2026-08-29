using Rewardly.Application.Interfaces.Bus.Command;

namespace Rewardly.Application.Commands.v1.DebitPoints;

public sealed record DebitPointsCommand(Guid AggregateId, int Points, string Reason) : ICommand<bool>;
