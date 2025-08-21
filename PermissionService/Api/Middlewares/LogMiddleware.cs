using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Api.Middlewares;

public class LogMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
{
    private readonly RequestDelegate _next = next;

    private readonly ILogger _logger = loggerFactory.CreateLogger("RequestHandler");

    public async Task Invoke(HttpContext context)
    {
        var correlationId = Guid.NewGuid().ToString("N");
        context.Items["CorrelationId"] = correlationId;

        var sw = Stopwatch.StartNew();

        try
        {
            _logger.LogInformation(
                "[{Timestamp}] ➡️  T:{TraceId} S:{SpanId} C:{CorrelationId} {Method} {Path} from {RemoteIpAddress}",
                DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                Activity.Current?.TraceId,
                Activity.Current?.SpanId,
                correlationId,
                context.Request.Method,
                context.Request.Path,
                context.Connection.RemoteIpAddress?.ToString()
            );

            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "[{Timestamp}] 💥 T:{TraceId} S:{SpanId} C:{CorrelationId} {Method} {Path} Exception occurred",
                DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                Activity.Current?.TraceId,
                Activity.Current?.SpanId,
                correlationId,
                context.Request.Method,
                context.Request.Path
            );
            throw;
        }
        finally
        {
            sw.Stop();
            _logger.LogInformation(
                "[{Timestamp}] ⬅️  T:{TraceId} S:{SpanId} C:{CorrelationId} {Method} {Path} {StatusIcon} {StatusCode} in {ElapsedMs}ms",
                DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                Activity.Current?.TraceId,
                Activity.Current?.SpanId,
                correlationId,
                context.Request.Method,
                context.Request.Path,
                GetStatusIcon(context.Response.StatusCode),
                context.Response.StatusCode,
                sw.ElapsedMilliseconds
            );
        }
    }

    private static string GetStatusIcon(int statusCode)
    {
        return statusCode switch
        {
            >= 200 and < 300 => "✅",
            >= 400 and < 500 => "⚠️",
            >= 500 => "❗",
            _ => "❓",
        };
    }
}
