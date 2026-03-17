using Microsoft.Extensions.Logging;

namespace Rewardly.Application.Logging;

public static class LoggerExtensions
{
   public static void LogAddRequest(
       this ILogger logger,
       object request,
       string correlationId,
       LogType type,
       string description,
       IDictionary<string, object>? metadata = null)
    {
        var normalizedCorrelation = NormalizedCorrelationId(correlationId, type);
        var context = BuildContext(metadata, normalizedCorrelation, request);

        using (logger.BeginScope(context))
        {
            Log(logger, type, description);
        }
    }

    public static void LogAddRequest(
        this ILogger logger,
        Exception exception,
        object request,
        string correlationId,
        LogType type,
        string description,
        IDictionary<string, object>? metadata = null)
    {
        var normalizedCorrelation = NormalizedCorrelationId(correlationId, type);
        var context = BuildContext(metadata, normalizedCorrelation, request);
     
        using (logger.BeginScope(context))
        {
            Log(logger, type, description, exception);
        }
    }

    private static void Log(ILogger logger, LogType type, string description, Exception? exception = null)
    {
        var logLevel = type switch
        {
            LogType.Warning => LogLevel.Warning,
            LogType.Error => LogLevel.Error,
            LogType.Critical => LogLevel.Critical,
            _ => LogLevel.Information
        };

        if (exception is null)
        {
            logger.Log(logLevel, description);
            return;
        }

        logger.Log(logLevel, exception, description);
    }

    private static Dictionary<string, object> BuildContext(IDictionary<string, object>? metadata, string correlationId, object request)
    {
        var context = new Dictionary<string, object>(metadata ?? new Dictionary<string, object>())
        {
            ["CorrelationId"] = correlationId,
            ["Request"] = request.GetType().Name
        };

        return context;
    }

    private static string NormalizedCorrelationId(string correlationId, LogType type) 
    {
        if (string.IsNullOrEmpty(correlationId))
        {
            return string.Empty;
        }

        if (type == LogType.Info)
        {
            return correlationId;
        }

        var segments = correlationId.Split('-', StringSplitOptions.RemoveEmptyEntries);
        return segments.Length == 0 ? correlationId : segments[^1].ToUpperInvariant();
    }
}
