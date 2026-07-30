namespace Rewardly.Application.Commands.v1.BlockAccount;

public sealed record BlockAccountCommand(Guid AggregateId, string Reason) : ICommand<bool>;
