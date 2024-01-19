using BookTracker.BusinessLogic.Exceptions.Common;
using FluentValidation;
using Mediator;

namespace BookTracker.BusinessLogic.Behaviors;

public class ValidationBehavior<TMessage, TResult> : IPipelineBehavior<TMessage, TResult> where TMessage : IMessage
{
    private readonly IEnumerable<IValidator<TMessage>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TMessage>> validators)
    {
        _validators = validators;
    }

    public async ValueTask<TResult> Handle(
        TMessage message,
        CancellationToken cancellationToken,
        MessageHandlerDelegate<TMessage, TResult> next)
    {
        if (!_validators.Any())
        {
            return await next(message, cancellationToken);
        }

        var validationTasks = _validators.Select(validator => validator.ValidateAsync(message, cancellationToken));
        
        var validationResults = await Task.WhenAll(validationTasks);

        var validationResult = Array.Find(validationResults, result => !result.IsValid);

        if (validationResult is null)
        {
            return await next(message, cancellationToken);
        }

        throw new ModelValidationException(validationResult.Errors[0].ErrorMessage);
    }
}