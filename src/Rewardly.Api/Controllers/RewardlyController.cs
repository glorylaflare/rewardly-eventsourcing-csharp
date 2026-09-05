using Rewardly.Application.Commands.v1.BlockAccount;
using Rewardly.Application.Commands.v1.CancelAccount;
using Rewardly.Application.Commands.v1.CreditPoints;
using Rewardly.Application.Commands.v1.DebitPoints;
using Rewardly.Application.Commands.v1.RedeemReward;
using Rewardly.Application.Interfaces.Bus.Command;
using Rewardly.Domain.Interfaces.v1;
using System.Net;

namespace Rewardly.Api.Controllers;

[ApiController]
[Route("api/v1/rewardly")]
public class RewardlyController : ApiControllerBase
{
    private readonly ICommandBus _commandBus;

    public RewardlyController(ICommandBus commandBus, INotification notification) : base(notification)
    {
        _commandBus = commandBus;
    }

    [HttpPost("account")]
    [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
    public Task<IActionResult> PostCreateAccount([FromBody] CreateAccountCommand command, CancellationToken cancellationToken)
        => ExecuteAsync(() =>_commandBus.SendAsync(command, cancellationToken), HttpStatusCode.Created);

    [HttpPost("block")]
    [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
    public Task<IActionResult> PostBlockAccount([FromBody] BlockAccountCommand command, CancellationToken cancellationToken)
        => ExecuteAsync(() =>_commandBus.SendAsync(command, cancellationToken), HttpStatusCode.Created);

    [HttpPost("cancel")]
    [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
    public Task<IActionResult> PostCancelAccount([FromBody] CancelAccountCommand command, CancellationToken cancellationToken)
        => ExecuteAsync(() =>_commandBus.SendAsync(command, cancellationToken), HttpStatusCode.Created);

    [HttpPost("credit")]
    [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
    public Task<IActionResult> PostCreditPoints([FromBody] CreditPointsCommand command, CancellationToken cancellationToken)
        => ExecuteAsync(() =>_commandBus.SendAsync(command, cancellationToken), HttpStatusCode.Created);

    [HttpPost("debit")]
    [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
    public Task<IActionResult> PostDebitPoints([FromBody] DebitPointsCommand command, CancellationToken cancellationToken)
        => ExecuteAsync(() =>_commandBus.SendAsync(command, cancellationToken), HttpStatusCode.Created);

    [HttpPost("redeem")]
    [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
    public Task<IActionResult> PostRedeemReward([FromBody] RedeemRewardCommand command, CancellationToken cancellationToken)
        => ExecuteAsync(() =>_commandBus.SendAsync(command, cancellationToken), HttpStatusCode.Created);
}
