namespace Rewardly.Application.Commands.v1.CreateAccount;

public class CreateAccountHandler : ICommandHandler<CreateAccountCommand, bool>
{
    private readonly IRewardlyAccountService _service;

    public CreateAccountHandler(IRewardlyAccountService service)
    {
        _service = service;
    }

    public async Task<bool> HandleAsync(CreateAccountCommand command, CancellationToken cancellationToken)
    {
        await _service.CreateAsync(command, cancellationToken);

        return true;
    }
}
