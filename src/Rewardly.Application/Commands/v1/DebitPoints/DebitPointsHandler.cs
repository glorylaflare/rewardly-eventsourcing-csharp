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
        DebitPointsRequest? request = DebitPointsMapper.ToRequest(command);

        await _service.DebitAsync(request, cancellationToken);

        return true;
    }
}
