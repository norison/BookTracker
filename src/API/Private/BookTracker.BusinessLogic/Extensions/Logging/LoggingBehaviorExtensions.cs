using Microsoft.Extensions.Logging;

namespace BookTracker.BusinessLogic.Extensions.Logging;

public static partial class LoggingBehaviorExtensions
{
    [LoggerMessage(
        EventId = 1,
        Level = LogLevel.Information,
        Message = "Start request processing. Name: {RequestName}")]
    public static partial void LogRequestProcessing(this ILogger logger, string requestName);
    
    [LoggerMessage(
        EventId = 2,
        Level = LogLevel.Trace,
        Message = "Request: {RequestJson}",
        SkipEnabledCheck = true)]
    public static partial void LogRequest(this ILogger logger, string requestJson);
    
    [LoggerMessage(
        EventId = 3,
        Level = LogLevel.Trace,
        Message = "Response: {ResponseJson}",
        SkipEnabledCheck = true)]
    public static partial void LogResponse(this ILogger logger, string responseJson);
    
    [LoggerMessage(
        EventId = 4,
        Level = LogLevel.Information,
        Message = "Request processed. Name: {RequestName}")]
    public static partial void LogRequestProcessed(this ILogger logger, string requestName);
    
    [LoggerMessage(
        EventId = 5,
        Level = LogLevel.Error,
        Message = "Error while processing request. Name: {RequestName}, Error: {Error}")]
    public static partial void LogRequestProcessingError(
        this ILogger logger,
        Exception exception,
        string requestName,
        string? error);
}