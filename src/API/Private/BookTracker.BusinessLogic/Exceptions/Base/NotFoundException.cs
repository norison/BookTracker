using System.Net;

namespace BookTracker.BusinessLogic.Exceptions.Base;

public abstract class NotFoundException : BookTrackerException
{
    protected NotFoundException(string? message = null) : base(message)
    {
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
    public override string Description => "Resource not found";
}
