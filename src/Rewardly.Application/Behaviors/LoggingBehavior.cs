using Microsoft.Extensions.Logging;
using Rewardly.Application.Interfaces.Behaviors;

namespace Rewardly.Application.Behaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(PipelineContext<TRequest> context, RequestHandlerDelegate<TResponse> next)
    {
        TResponse? result = await next();

        return result;
    }
}
