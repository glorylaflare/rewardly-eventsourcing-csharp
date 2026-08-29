using Rewardly.Application.Interfaces.Bus.Command;

namespace Rewardly.Application.Commands.v1.CreateAccount;

public sealed record CreateAccountCommand(Guid UserId) : ICommand<bool>;
