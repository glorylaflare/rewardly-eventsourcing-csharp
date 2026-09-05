using Rewardly.Application.Interfaces.Bus.Command;

namespace Rewardly.Application.Commands.v1.CancelAccount;

public sealed record CancelAccountCommand(Guid AggregateId, string Reason) : ICommand<bool>;
