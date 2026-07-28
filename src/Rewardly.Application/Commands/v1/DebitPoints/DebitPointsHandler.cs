namespace Rewardly.Application.Commands.v1.DebitPoints;

public class DebitPointsHandler : ICommandHandler<DebitPointsCommand, bool>
{
    private readonly IRewardlyAccountService _service;

    public DebitPointsHandler(IRewardlyAccountService service)
    {
        _service = service;
    }

    public async Task<bool> HandleAsync(DebitPointsCommand command, CancellationToken cancellationToken)
    {
        await _service.DebitAsync(command, cancellationToken);

        return true;
    }
}
