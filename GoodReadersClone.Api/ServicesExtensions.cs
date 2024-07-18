﻿using GoodReadersClone.Domain.Entities;
using GoodReadersClone.Infrastructure.DataAccess.Abstractions;
using GoodReadersClone.Infrastructure.DataAccess;
using GoodReadersClone.Infrastructure.DataAccess.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GoodReadersClone.Application.Features;
using GoodReadersClone.Api.Helpers;

namespace GoodReadersClone.Api;

public static class ServicesExtensions
{
    public static void RegisterDomainServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static void RegisterIdentity(this IServiceCollection services)
    {
        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
    }

    public static void RegisterApplicationDbContext(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });
    }

    public static void RegisterMediatR(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(MediatREntryPoint).Assembly);
        });
    }

    public static void RegisterOptions(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<MaintenanceOptions>(configuration.GetSection("MaintenanceMode"));

    }
}
