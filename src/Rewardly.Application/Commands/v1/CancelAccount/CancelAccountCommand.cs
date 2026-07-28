namespace Rewardly.Application.Commands.v1.CancelAccount;

public sealed record CancelAccountCommand(Guid AccountId, string Reason) : ICommand<bool>;