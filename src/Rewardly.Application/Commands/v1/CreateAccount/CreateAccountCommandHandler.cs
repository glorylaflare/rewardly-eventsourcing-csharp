using Rewardly.Application.Interfaces.Bus.Command;

namespace Rewardly.Application.Commands.v1.CreateAccount;

public class CreateAccountCommandHandler : ICommandHandler<CreateAccountCommand, bool>
{
    private readonly IRewardlyAccountService _service;

    public CreateAccountCommandHandler(IRewardlyAccountService service)
    {
        _service = service;
    }

    public async Task<bool> HandleAsync(CreateAccountCommand command, CancellationToken cancellationToken)
    {
        CreateAccountRequest? request = CreateAccountMapper.ToRequest(command);

        await _service.CreateAsync(request, cancellationToken);

        return true;
    }
}
