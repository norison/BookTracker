using System.Net;

namespace BookTracker.BusinessLogic.Exceptions.Base;

public abstract class BookTrackerException : Exception
{
    protected BookTrackerException(string? message = null) : base(message)
    {
    }

    public abstract HttpStatusCode StatusCode { get; }
    public abstract int Code { get; }
    public abstract string Description { get; }
}
