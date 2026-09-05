using Rewardly.Application.Interfaces.Bus.Command;

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
        BlockAccountRequest? request = BlockAccountMapper.ToRequest(command);

        await _service.BlockAsync(request, cancellationToken);

        return true;
    }
}
