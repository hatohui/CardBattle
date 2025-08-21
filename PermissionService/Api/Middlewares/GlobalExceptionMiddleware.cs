using System.Net;
using System.Text.Json;
using Grpc.Core;

public class GlobalExceptionMiddleware(
    RequestDelegate next,
    ILogger<GlobalExceptionMiddleware> logger
)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger = logger;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            if (IsGrpcRequest(context))
            {
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var errorResponse = new
                {
                    message = ex.Message,
                    detail = ex.InnerException?.Message,
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
            }
        }
    }

    private static bool IsGrpcRequest(HttpContext context)
    {
        return context.Request.ContentType == "application/grpc"
            || context.Request.Protocol.StartsWith("HTTP/2");
    }
}
