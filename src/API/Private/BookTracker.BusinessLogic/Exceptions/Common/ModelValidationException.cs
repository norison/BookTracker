using BookTracker.BusinessLogic.Exceptions.Base;

namespace BookTracker.BusinessLogic.Exceptions.Common;

public class ModelValidationException : ValidationException
{
    public ModelValidationException(string message) : base(message)
    {
    }

    public override int Code => (int)CommonCode.ModelValidation;
}