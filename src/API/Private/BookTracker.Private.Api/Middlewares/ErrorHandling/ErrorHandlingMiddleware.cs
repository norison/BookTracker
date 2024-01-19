using BookTracker.BusinessLogic.Exceptions.Base;
using BookTracker.BusinessLogic.Exceptions.Common;
using BookTracker.Private.Api.Contracts;

namespace BookTracker.Private.Api.Middlewares.ErrorHandling;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(httpContext, exception);
        }
    }

    private static async ValueTask HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        var bookTrackerException = exception as BookTrackerException ?? new NonGeneralException();

        var errorResponse = new ErrorResponse
        {
            Code = bookTrackerException.Code,
            Description = bookTrackerException.Description,
            Message = bookTrackerException.Message
        };

        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = (int) bookTrackerException.StatusCode;
        await httpContext.Response.WriteAsJsonAsync(errorResponse);
    }
}