using System.Net;
using BookTracker.BusinessLogic.Exceptions.Base;

namespace BookTracker.BusinessLogic.Exceptions.Common;

public class NonGeneralException : BookTrackerException
{
    public NonGeneralException(string? message = null) : base(message)
    {
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;
    public override int Code => (int)CommonCode.NonGeneral;
    public override string Description => "Internal server error";
}
