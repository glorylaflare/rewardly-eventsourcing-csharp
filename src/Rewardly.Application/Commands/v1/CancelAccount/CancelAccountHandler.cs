namespace Rewardly.Application.Commands.v1.CancelAccount;

public class CancelAccountHandler : ICommandHandler<CancelAccountCommand, bool>
{
    private readonly IRewardlyAccountService _service;

    public CancelAccountHandler(IRewardlyAccountService service)
    {
        _service = service;
    }

    public async Task<bool> HandleAsync(CancelAccountCommand command, CancellationToken cancellationToken)
    {
        CancelAccountRequest? request = CancelAccountMapper.ToRequest(command);

        await _service.CancelAsync(request, cancellationToken);

        return true;
    }
}
