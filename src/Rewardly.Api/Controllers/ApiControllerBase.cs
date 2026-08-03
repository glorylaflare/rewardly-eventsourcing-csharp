using Rewardly.Application.Responses;
using Rewardly.Domain.Interfaces.v1;
using System.Net;

namespace Rewardly.Api.Controllers;

public abstract class ApiControllerBase : ControllerBase
{
    private readonly INotification _notification;

    protected ApiControllerBase(INotification notification)
    {
        _notification = notification;
    }

    protected async Task<IActionResult> ExecuteAsync<TResponse>(Func<Task<TResponse>> request, HttpStatusCode statusCode) 
    {
        TResponse data = await request();

        if (_notification.HasNotifications)
            return StatusCode((int)HttpStatusCode.BadRequest, ResponseBase<TResponse>.Fail(_notification.Notifications.Select(_ => _.Message).ToArray()));

        return StatusCode((int)statusCode, ResponseBase<TResponse>.Ok(data));
    }
}
