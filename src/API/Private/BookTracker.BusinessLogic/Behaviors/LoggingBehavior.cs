using BookTracker.BusinessLogic.Extensions.Logging;
using Mediator;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BookTracker.BusinessLogic.Behaviors;

public class LoggingBehavior<TMessage, TResponse> : IPipelineBehavior<TMessage, TResponse> where TMessage : IMessage
{
    private readonly ILogger<LoggingBehavior<TMessage, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TMessage, TResponse>> logger)
    {
        _logger = logger;
    }

    public async ValueTask<TResponse> Handle(
        TMessage message,
        CancellationToken cancellationToken,
        MessageHandlerDelegate<TMessage, TResponse> next)
    {
        var messageTypeName = message.GetType().Name;

        try
        {
            LogRequest(message, messageTypeName);

            var response = await next(message, cancellationToken);

            LogResponse(response, messageTypeName);

            return response;
        }
        catch (Exception exception)
        {
            _logger.LogRequestProcessingError(exception, messageTypeName, exception.Message);
            throw;
        }
    }

    private void LogRequest(TMessage message, string messageTypeName)
    {
        _logger.LogRequestProcessing(messageTypeName);

        if (_logger.IsEnabled(LogLevel.Trace))
        {
            _logger.LogRequest(JsonConvert.SerializeObject(message));
        }
    }

    private void LogResponse(TResponse response, string messageTypeName)
    {
        if (_logger.IsEnabled(LogLevel.Trace))
        {
            _logger.LogResponse(JsonConvert.SerializeObject(response));
        }

        _logger.LogRequestProcessed(messageTypeName);
    }
}