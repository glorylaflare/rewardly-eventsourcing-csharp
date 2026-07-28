using System.Reflection;

namespace Rewardly.Application.Logging;

public static class LogBuilder
{
    public static Dictionary<string, object> BuildRequestLogData(
        string stage,
        IDictionary<string, object>? fields = null)
    {
        var logData = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
        {
            ["RequestDate"] = DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"),
            ["Stage"] = stage,
        };

        if (fields is not null)
        {
            foreach (KeyValuePair<string, object> map in fields)
            {
                logData[map.Key] = map.Value ?? string.Empty;
            }
        }

        return logData;
    }

    public static Dictionary<string, object> BuildRequestLogData<TRequest>(
        TRequest request,
        string stage,
        IDictionary<string, object>? fields = null,
        IDictionary<string, string>? extra = null)
    {
        var logData = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
        {
            ["RequestDate"] = DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"),
            ["RequestName"] = typeof(TRequest).Name,
            ["Stage"] = stage,
        };

        if (request is not null)
        {
            if (fields is not null && fields.Count > 0)
            {
                foreach (var map in fields)
                {
                    logData[map.Key] = map.Value ?? string.Empty;
                }
            }
            else
            {
                foreach (PropertyInfo prop in typeof(TRequest).GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    if (prop.GetIndexParameters().Length > 0) continue;
                    logData[prop.Name] = prop.GetValue(request) ?? string.Empty;
                }
            }
        }

        if (extra is not null)
        {
            foreach (KeyValuePair<string, string> map in extra)
            {
                logData[map.Key] = map.Value ?? string.Empty;
            }
        }

        return logData;
    }
}
