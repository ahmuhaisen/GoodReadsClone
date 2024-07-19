using GoodReadersClone.Api.Mapper;
using GoodReadersClone.Api;
using GoodReadersClone.Api.Middlewares;
using Microsoft.OpenApi.Models;
using GoodReadersClone.Infrastructure.Exceptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.RegisterSwaggerWithOptions();

builder.Services.RegisterIdentity();

builder.Services.RegisterApplicationDbContext(builder.Configuration);

builder.Services.RegisterDomainServices();

builder.Services.RegisterMediatR();

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.RegisterOptions(builder.Configuration);

builder.Services.RegisterJwt(builder.Configuration);

builder.Services.ConfigureVersioning();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddProblemDetails();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<MaintenanceMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseExceptionHandler();

app.MapControllers();

app.Run();
