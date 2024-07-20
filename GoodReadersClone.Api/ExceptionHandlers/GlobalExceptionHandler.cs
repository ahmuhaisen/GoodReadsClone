using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;
namespace GoodReadersClone.Api.ExceptionHandlers;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> _logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Unhandled exception occurred: {Message}", exception.Message);

        var details = new ProblemDetails
        {
            Detail = exception.Message,
            Instance = httpContext.Request.Path,
            Status = (int)HttpStatusCode.InternalServerError,
            Title = "Server Error",
            Type = "Error"
        };

        details.Extensions["ExceptionType"] = exception.GetType().ToString();

        var response = JsonSerializer.Serialize(details);

        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        await httpContext.Response.WriteAsync(response, cancellationToken);

        return true;
    }
}
