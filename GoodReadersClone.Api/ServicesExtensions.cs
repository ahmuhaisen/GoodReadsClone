using Asp.Versioning;
using GoodReadersClone.Api.ExceptionHandlers;
using GoodReadersClone.Application.Abstractions;
using GoodReadersClone.Application.Behaviors;
using GoodReadersClone.Application.Features;
using GoodReadersClone.Application.Mapper;
using GoodReadersClone.Infrastructure.DataAccess;
using GoodReadersClone.Infrastructure.DataAccess.Abstractions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace GoodReadersClone.Api;


public static class SertvicesExtensions
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<ApplicationUser, IdentityRole>()
                   .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(MediatREntryPoint).Assembly);
        });

        services.Configure<MaintenanceOptions>(configuration.GetSection("MaintenanceMode"));
        services.Configure<JwtOptions>(configuration.GetSection("Jwt"));


        var jwtOptions = configuration.GetSection("Jwt").Get<JwtOptions>();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(o =>
        {
            o.RequireHttpsMetadata = false;
            o.SaveToken = true;
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = jwtOptions?.Issuer,
                ValidAudience = jwtOptions?.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions?.SigningKey!)),
                ClockSkew = TimeSpan.Zero
            };
        });

        services.AddSwaggerGen(setup =>
        {
            setup.SwaggerGeneratorOptions.SwaggerDocs.Add("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Good Readers Clone",
                Description = "A Web API project using ASP.NET 8.0 demonistrates the basic features of GoodReaders website.",
                Contact = new OpenApiContact { Name = "Ahmad Muhaisen", Email = "ahmuhaisen03@gmail.com" }
            });
        });


        services.AddApiVersioning(options =>
        {
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0); //1.0
            options.ReportApiVersions = true;
            options.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader());
        })
            .AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'V";
            options.SubstituteApiVersionInUrl = true;
        });

        services.AddExceptionHandler<GlobalExceptionHandler>();

        return services;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile).Assembly);
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));

        return services;
    }

    public static IServiceCollection AddInfrastructuerServices
    (this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }

    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        return services;
    }
}
