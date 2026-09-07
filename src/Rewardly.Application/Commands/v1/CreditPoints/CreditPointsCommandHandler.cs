using Rewardly.Application.Interfaces.Bus.Command;

namespace Rewardly.Application.Commands.v1.CreditPoints;

public class CreditPointsCommandHandler : ICommandHandler<CreditPointsCommand, bool>
{
    private readonly IRewardlyAccountService _service;

    public CreditPointsCommandHandler(IRewardlyAccountService service)
    {
        _service = service;
    }

    public async Task<bool> HandleAsync(CreditPointsCommand command, CancellationToken cancellationToken)
    {
        CreditPointsRequest? request = CreditPointsMapper.ToRequest(command);

        await _service.CreditAsync(request, cancellationToken);

        return true;
    }
}
