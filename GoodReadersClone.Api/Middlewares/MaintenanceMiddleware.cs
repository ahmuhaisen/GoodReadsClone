namespace GoodReadsClone.Api.Middlewares;

public class MaintenanceMiddleware(RequestDelegate _next, IOptionsMonitor<MaintenanceOptions> _options)
{
    public async Task Invoke(HttpContext context)
    {
        if (IsInMaintenanceMode())
        {
            await context.Response.WriteAsync("The system is in Maintenance Mode, try again later");
            return;
        }

        await _next(context);
    }

    private bool IsInMaintenanceMode() => _options.CurrentValue.IsEnabled;
}
