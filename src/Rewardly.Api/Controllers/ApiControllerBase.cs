using Rewardly.Application.Responses;
using Rewardly.Domain.Interfaces.v1;

namespace Rewardly.Api.Controllers;

public abstract class ApiControllerBase : ControllerBase
{
    private readonly INotification _notification;

    protected ApiControllerBase(INotification notification)
    {
        _notification = notification;
    }

    protected IActionResult Result<T>(T data)
    {
        if (_notification.HasNotifications)
            return BadRequest(ResponseBase<T>.Fail(_notification.Notifications.Select(_ => _.Message).ToArray()));

        return Ok(ResponseBase<T>.Ok(data));
    }
}
