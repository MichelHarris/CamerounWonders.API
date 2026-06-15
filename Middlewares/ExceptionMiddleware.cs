using System.Net;
using System.Text.Json;

namespace CamerounWonders.API.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(
        RequestDelegate next,
        ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Une exception est survenue.");

            context.Response.StatusCode =
                (int)HttpStatusCode.InternalServerError;

            context.Response.ContentType =
                "application/json";

            var response = new
            {
                Message = ex.Message,
                InnerException = ex.InnerException?.Message,
                StackTrace = ex.StackTrace
            };

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(response));
        }
    }
}