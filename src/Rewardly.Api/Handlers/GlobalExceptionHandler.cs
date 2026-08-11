using Microsoft.AspNetCore.Diagnostics;
using Rewardly.Api.Mapper;

namespace Rewardly.Api.Handlers;

public sealed class GlobalExceptionHandler : IExceptionHandler
{
    private readonly IExceptionMapper _exceptionMapper;
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(
        IExceptionMapper exceptionMapper,
        ILogger<GlobalExceptionHandler> logger)
    {
        _exceptionMapper = exceptionMapper;
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        ExceptionMapping mapping = _exceptionMapper.Map(exception);

        _logger.LogError(
            exception,
            "Unhandled exception. ErrorCode: {ErrorCode}",
            mapping.ErrorCode);

        var problemDetails = new ProblemDetails
        {
            Status = (int)mapping.StatusCode,
            Title = "An error occurred while processing the request.",
            Detail = mapping.Message,
            Instance = httpContext.Request.Path
        };

        problemDetails.Extensions["errorCode"] = mapping.ErrorCode;

        httpContext.Response.StatusCode = (int)mapping.StatusCode;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}
