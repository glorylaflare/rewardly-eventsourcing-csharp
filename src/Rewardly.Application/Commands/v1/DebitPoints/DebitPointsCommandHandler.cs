using Rewardly.Application.Interfaces.Bus.Command;

namespace Rewardly.Application.Commands.v1.DebitPoints;

public class DebitPointsCommandHandler : ICommandHandler<DebitPointsCommand, bool>
{
    private readonly IRewardlyAccountService _service;

    public DebitPointsCommandHandler(IRewardlyAccountService service)
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
