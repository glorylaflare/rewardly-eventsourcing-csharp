using Rewardly.Application.Commands.v1.BlockAccount;
using Rewardly.Application.Commands.v1.CancelAccount;
using Rewardly.Application.Commands.v1.CreditPoints;
using Rewardly.Application.Commands.v1.DebitPoints;
using Rewardly.Application.Commands.v1.RedeemReward;
using Rewardly.Application.Interfaces.Bus;
using Rewardly.Domain.Interfaces.v1;

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
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PostCreateAccount([FromBody] CreateAccountCommand command)
    {
        bool result = await _commandBus.SendAsync(command);
        return Result(result);
    }

    [HttpPost("block")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PostBlockAccount([FromBody] BlockAccountCommand command)
    {
        bool result = await _commandBus.SendAsync(command);
        return Result(result);
    }

    [HttpPost("cancel")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PostCancelAccount([FromBody] CancelAccountCommand command)
    {
        bool result = await _commandBus.SendAsync(command);
        return Result(result);
    }

    [HttpPost("credit")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PostCreditPoints([FromBody] CreditPointsCommand command)
    {
        bool result = await _commandBus.SendAsync(command);
        return Result(result);
    }

    [HttpPost("debit")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PostCDebitPoints([FromBody] DebitPointsCommand command)
    {
        bool result = await _commandBus.SendAsync(command);
        return Result(result);
    }

    [HttpPost("redeem")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PostRedeemReward([FromBody] RedeemRewardCommand command)
    {
        bool result = await _commandBus.SendAsync(command);
        return Result(result);
    }
}
