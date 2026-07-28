using Rewardly.Application.Commands.v1.BlockAccount;
using Rewardly.Application.Commands.v1.CancelAccount;
using Rewardly.Application.Commands.v1.CreateAccount;
using Rewardly.Application.Commands.v1.CreditPoints;
using Rewardly.Application.Commands.v1.DebitPoints;
using Rewardly.Application.Commands.v1.RedeemReward;

namespace Rewardly.Application.Interfaces.Services.v1;

/// <summary>
/// 
/// </summary>
public interface IRewardlyAccountService
{
    Task BlockAsync(BlockAccountCommand command, CancellationToken cancellationToken);
    Task CancelAsync(CancelAccountCommand command, CancellationToken cancellationToken);
    Task CreateAsync(CreateAccountCommand command, CancellationToken cancellationToken);
    Task CreditAsync(CreditPointsCommand command, CancellationToken cancellationToken);
    Task DebitAsync(DebitPointsCommand command, CancellationToken cancellationToken);
    Task RedeemAsync(RedeemRewardCommand command, CancellationToken cancellationToken);
}