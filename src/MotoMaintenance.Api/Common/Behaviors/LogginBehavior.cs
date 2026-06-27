using MediatR;
using Microsoft.Extensions.Logging;

namespace MotoMaintenance.Api.Common.Behaviors;

public sealed class LoggingBehavior<TRequest, TResponse>(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    public async Task<TResponse> Handle(
        TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken ct)
    {
        var name = typeof(TRequest).Name;
        logger.LogInformation("Handling {Request}", name);

        try
        {
            return await next();
        }
        finally
        {
            logger.LogInformation("Handled  {Request}", name);
        }
    }
}