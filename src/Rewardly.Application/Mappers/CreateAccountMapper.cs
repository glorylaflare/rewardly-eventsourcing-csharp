using Rewardly.Application.Commands.v1.CreateAccount;
using Rewardly.Application.Requests;

namespace Rewardly.Application.Mappers;

internal static class CreateAccountMapper
{
    public static CreateAccountRequest ToRequest(CreateAccountCommand source)
        => new CreateAccountRequest(source.UserId);
}
