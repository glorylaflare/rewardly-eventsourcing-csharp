namespace Rewardly.Application.Commands.v1.BlockAccount;

public class BlockAccountHandler : ICommandHandler<BlockAccountCommand, bool>
{
    private readonly IRewardlyAccountService _service;

    public BlockAccountHandler(IRewardlyAccountService service)
    {
        _service = service;
    }

    public async Task<bool> HandleAsync(BlockAccountCommand command, CancellationToken cancellationToken)
    {
        await _service.BlockAsync(command, cancellationToken);

        return true;
    }
}
