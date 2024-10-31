using FluentValidation;
using GoodReadsClone.Application.Abstractions;
using GoodReadsClone.Application.Behaviors;
using GoodReadsClone.Application.Mapper;
using GoodReadsClone.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GoodReadsClone.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile).Assembly);
        services.AddScoped<IAuthService, AuthenticationService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));

        services.AddValidatorsFromAssembly(typeof(AssemblyReference).Assembly);

        return services;
    }
}
