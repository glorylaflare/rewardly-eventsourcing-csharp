using Rewardly.Application.Commands.v1.BlockAccount;
using Rewardly.Application.Commands.v1.CancelAccount;
using Rewardly.Application.Commands.v1.CreditPoints;
using Rewardly.Application.Commands.v1.DebitPoints;
using Rewardly.Application.Commands.v1.RedeemReward;
using Rewardly.Application.Interfaces.Bus.Command;
using Rewardly.Application.Interfaces.Bus.Query;
using Rewardly.Application.Queries.v1.GetAccount;
using Rewardly.Application.Queries.v1.GetBalance;
using Rewardly.Application.Queries.v1.GetTransactions;
using Rewardly.Domain.Interfaces.v1;
using System.Net;

namespace Rewardly.Api.Controllers;

[ApiController]
[Route("api/v1/rewardly")]
public class RewardlyController : ApiControllerBase
{
    private readonly ICommandBus _commandBus;
    private readonly IQueryBus _queryBus;

    public RewardlyController(ICommandBus commandBus, INotification notification, IQueryBus queryBus) : base(notification)
    {
        _commandBus = commandBus;
        _queryBus = queryBus;
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

    [HttpGet("account/{userid:guid}")]
    [ProducesResponseType(typeof(GetAccountResponse), StatusCodes.Status200OK)]
    public Task<IActionResult> GetAccount(Guid userId, CancellationToken cancellationToken)
        => ExecuteAsync(() => _queryBus.SendAsync(new GetAccountQuery(userId), cancellationToken), HttpStatusCode.OK);

    [HttpGet("account/{userid:guid}/balance")]
    [ProducesResponseType(typeof(GetBalanceResponse), StatusCodes.Status200OK)]
    public Task<IActionResult> GetBalance(Guid userId, CancellationToken cancellationToken)
        => ExecuteAsync(() => _queryBus.SendAsync(new GetBalanceQuery(userId), cancellationToken), HttpStatusCode.OK);

    [HttpGet("account/{userid:guid}/transactions")]
    [ProducesResponseType(typeof(GetTransactionsResponse), StatusCodes.Status200OK)]
    public Task<IActionResult> GetTransactions(Guid userId, [FromQuery] int page = 1, [FromQuery] int pageSize = 10, CancellationToken cancellationToken = default)
        => ExecuteAsync(() => _queryBus.SendAsync(new GetTransactionsQuery(userId, page, pageSize), cancellationToken), HttpStatusCode.OK);
}
