using Rewardly.Application.Commands.v1.BlockAccount;
using Rewardly.Application.Commands.v1.CancelAccount;
using Rewardly.Application.Commands.v1.CreateAccount;
using Rewardly.Application.Commands.v1.CreditPoints;
using Rewardly.Application.Commands.v1.DebitPoints;
using Rewardly.Application.Commands.v1.RedeemReward;

namespace Rewardly.Application.Services.v1;

public class RewardlyAccountService : IRewardlyAccountService
{
    public Task BlockAsync(BlockAccountCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task CancelAsync(CancelAccountCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(CreateAccountCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task CreditAsync(CreditPointsCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DebitAsync(DebitPointsCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task RedeemAsync(RedeemRewardCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
