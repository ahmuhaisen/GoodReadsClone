using GoodReadersClone.Application.Options;
using Microsoft.Extensions.Options;

namespace GoodReadersClone.Api.Middlewares;

public class MaintenanceMiddleware(RequestDelegate _next, IOptionsMonitor<MaintenanceOptions> _options)
{
    public async Task Invoke(HttpContext context)
    {
        if (IsMaintenanceModeEnabled())
        {
            await context.Response.WriteAsync("The system is in Maintenance Mode, try again later");
            return;
        }

        await _next(context);
    }

    private bool IsMaintenanceModeEnabled() => _options.CurrentValue.IsEnabled;
}
