namespace Rewardly.Application.Commands.v1.BlockAccount;

public sealed record BlockAccountCommand(Guid AccountId, string Reason) : ICommand<bool>;