using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Rewardly.Application.Pipeline.Behaviors;

public sealed class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
    where TRequest : ICommand<TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> HandleAsync(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        Stopwatch? stopwatch = Stopwatch.StartNew();

        _logger.LogInformation("Handling command {Command}", typeof(TRequest).Name);

        TResponse? response = await next();

        stopwatch.Stop();

        _logger.LogInformation("Handled command {Command} in {Elapsed} ms", typeof(TRequest).Name, stopwatch.ElapsedMilliseconds);

        return response;
    }
}
