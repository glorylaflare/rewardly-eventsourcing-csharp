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

    [HttpPost("accounts")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PostCreateAccount([FromBody] CreateAccountCommand command)
    {
        bool result = await _commandBus.SendAsync(command);
        return Result(result);
    }
}
