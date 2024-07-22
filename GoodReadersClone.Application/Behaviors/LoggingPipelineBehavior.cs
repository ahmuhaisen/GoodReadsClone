﻿
namespace GoodReadersClone.Application.Behaviors;


public class LoggingPipelineBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : ApiResponse
{
    private readonly ILogger<LoggingPipelineBehavior<TRequest, TResponse>> _logger;

    public LoggingPipelineBehavior(ILogger<LoggingPipelineBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }


    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogInformation("[Starting Request] {@RequestName}, {@DateTime}",
            typeof(TRequest).Name,
            DateTime.Now);

        var result = await next();

        if(!result.Success)
            _logger.LogError("[Request Failuer] {@RequestName}, {@ErrorMessage}, {@DateTime}",
            typeof(TRequest).Name,
            result.Message,
            DateTime.Now);

        _logger.LogInformation("[Completed Request] {@RequestName}, {@DateTime}",
            typeof(TRequest).Name,
            DateTime.Now);

        return result;
    }
}
