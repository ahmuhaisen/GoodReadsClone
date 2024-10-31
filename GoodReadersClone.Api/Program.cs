using GoodReadsClone.Api;
using GoodReadsClone.Api.Middlewares;
using Serilog;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(config)
    .CreateLogger();


try
{
    Log.Information("Starting the application");

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();

    builder.Host.UseSerilog();

    builder.Services.AddDomainServices()
        .AddInfrastructuerServices(builder.Configuration)
        .AddApplicationServices()
        .AddPresentationServices(builder.Configuration);

    //CORS
    builder.Services.AddCors();

    builder.Services.AddProblemDetails();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseCors(cfg =>
    {
        cfg.AllowAnyHeader()
           .AllowAnyMethod()
           .AllowAnyOrigin();
    });


    app.UseSerilogRequestLogging();

    app.UseMiddleware<MaintenanceMiddleware>();

    app.UseHttpsRedirection();

    app.UseAuthentication();

    app.UseAuthorization();

    app.UseExceptionHandler();

    app.MapControllers();

    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Application failed to start");
}
finally
{
    Log.CloseAndFlush();
}