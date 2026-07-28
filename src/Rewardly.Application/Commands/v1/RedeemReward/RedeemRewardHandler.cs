namespace Rewardly.Application.Commands.v1.RedeemReward;

public class RedeemRewardHandler : ICommandHandler<RedeemRewardCommand, bool>
{
    private readonly IRewardlyAccountService _service;

    public RedeemRewardHandler(IRewardlyAccountService service)
    {
        _service = service;
    }

    public async Task<bool> HandleAsync(RedeemRewardCommand command, CancellationToken cancellationToken)
    {
        await _service.RedeemAsync(command, cancellationToken);

        return true;
    }
}
