using System.Net;

namespace BookTracker.BusinessLogic.Exceptions.Base;

public abstract class ValidationException : BookTrackerException
{
    protected ValidationException(string? message = null) : base(message)
    {
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    public override string Description => "Invalid data provided";
}
