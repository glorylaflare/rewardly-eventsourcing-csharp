using Microsoft.Extensions.Logging;

namespace Rewardly.Application.Logging;

public static class LoggerExtensions
{
    private const int CORRELATION_ID_SHORT_LENGTH = 8;

    public static void LogAddRequest(
        this ILogger logger,
        string operation,
        AddLogType type,
        string description,
        string? correlationId = null,
        IDictionary<string, object>? metadata = null)
    {
        LogAddRequestInternal(logger, null, operation, correlationId, type, description, metadata);
    }

    public static void LogAddRequest(
        this ILogger logger,
        Exception exception,
        string operation,
        AddLogType type,
        string description,
        string? correlationId = null,
        IDictionary<string, object>? metadata = null)
    {
        LogAddRequestInternal(logger, exception, operation, correlationId, type, description, metadata);
    }

    public static IDisposable BeginCorrelationScope(this ILogger logger, string? correlationId = null)
    {
        string? safeCorrelationId = GetCorrelationIdOrDefault(correlationId) ?? Guid.NewGuid().ToString("N");

        var scopeContext = new Dictionary<string, object>
        {
            ["CorrelationId"] = safeCorrelationId,
            ["CorrelationIdShort"] = BuildShortCorrelationId(safeCorrelationId),
        };

        return logger.BeginScope(scopeContext)!;
    }

    private static void LogAddRequestInternal(
        ILogger logger,
        Exception? exception,
        string operation,
        string? correlationId,
        AddLogType type,
        string description,
        IDictionary<string, object>? metadata)
    {
        IDictionary<string, object>? context = BuildContext(metadata, correlationId, operation);

        using (logger.BeginScope(context))
        {
            Log(logger, operation, type, description, exception);
        }
    }

    private static void Log(
        ILogger logger,
        string operation,
        AddLogType type,
        string description,
        Exception? exception = null)
    {
        LogLevel logLevel = type switch
        {
            AddLogType.Debug => LogLevel.Debug,
            AddLogType.Warn => LogLevel.Warning,
            AddLogType.Error => LogLevel.Error,
            _ => LogLevel.Information
        };

        var normalizedType = type.ToString().ToUpperInvariant();
        var normalizedDescription = string.IsNullOrWhiteSpace(description) ? string.Empty : description;

        if (exception is null)
        {
            logger.Log(logLevel, $"[{normalizedType}] [{operation}] {normalizedDescription}");
            return;
        }

        logger.Log(logLevel, exception, $"[{normalizedType}] [{operation}] {normalizedDescription}");
    }

    private static IDictionary<string, object> BuildContext(
        IDictionary<string, object>? metadata,
        string? correlationId,
        string operation)
    {
        var context = new Dictionary<string, object>(metadata ?? new Dictionary<string, object>());

        context["Operation"] = operation;

        if (!string.IsNullOrWhiteSpace(correlationId) && !context.ContainsKey("CorrelationId"))
        {
            context["CorrelationId"] = correlationId;
            context["CorrelationIdShort"] = BuildShortCorrelationId(correlationId);
        }

        return context;
    }

    private static string? GetCorrelationIdOrDefault(string? correlationId)
    {
        return string.IsNullOrWhiteSpace(correlationId) ? null : correlationId;
    }

    private static string BuildShortCorrelationId(string correlationId)
    {
        if (string.IsNullOrWhiteSpace(correlationId))
        {
            return string.Empty;
        }

        return correlationId.Length <= CORRELATION_ID_SHORT_LENGTH
            ? correlationId.ToUpperInvariant()
            : correlationId[^CORRELATION_ID_SHORT_LENGTH..].ToUpperInvariant();
    }
}
