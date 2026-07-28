namespace Rewardly.Application.Commands.v1.CreditPoints;

public class CreditPointsHandler : ICommandHandler<CreditPointsCommand, bool>
{
    private readonly IRewardlyAccountService _service;

    public CreditPointsHandler(IRewardlyAccountService service)
    {
        _service = service;
    }

    public async Task<bool> HandleAsync(CreditPointsCommand command, CancellationToken cancellationToken)
    {
        await _service.CreditAsync(command, cancellationToken);

        return true;
    }
}
