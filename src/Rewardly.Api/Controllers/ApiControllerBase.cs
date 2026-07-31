using Rewardly.Application.Responses;
using Rewardly.Domain.Interfaces.v1;

namespace Rewardly.Api.Controllers;

public abstract class ApiControllerBase : ControllerBase
{
    private readonly INotification _notification;
    private readonly ILogger<ApiControllerBase> _logger;

    protected ApiControllerBase(INotification notification, ILogger<ApiControllerBase> logger)
    {
        _notification = notification;
        _logger = logger;
    }

    protected IActionResult Result<T>(T data)
    {
        if (_notification.HasNotifications)
            return BadRequest(ResponseBase<T>.Fail(_notification.Notifications.Select(_ => _.Message).ToArray()));

        return Ok(ResponseBase<T>.Ok(data));
    }
}
