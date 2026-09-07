using Rewardly.Application.Interfaces.Bus.Command;

namespace Rewardly.Application.Commands.v1.RedeemReward;

public class RedeemRewardCommandHandler : ICommandHandler<RedeemRewardCommand, bool>
{
    private readonly IRewardlyAccountService _service;

    public RedeemRewardCommandHandler(IRewardlyAccountService service)
    {
        _service = service;
    }

    public async Task<bool> HandleAsync(RedeemRewardCommand command, CancellationToken cancellationToken)
    {
        RedeemRewardRequest? request = RedeemRewardMapper.ToRequest(command);

        await _service.RedeemAsync(request, cancellationToken);

        return true;
    }
}
