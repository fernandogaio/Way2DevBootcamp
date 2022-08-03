using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Way2DevBootcamp.Application.Notifications;

namespace Way2DevBootcamp.Application.Core;
public class ValidationRequestBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse> where TResponse : CommandResponse {
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    private readonly IMediator _mediator;

    public ValidationRequestBehavior(IEnumerable<IValidator<TRequest>> validators, IMediator mediator) {
        _validators = validators;
        _mediator = mediator;
    }

    public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next) {
        var failures = _validators
            .Select(v => v.ValidateAsync(request).Result)
            .SelectMany(result => result.Errors)
            .Where(f => f != null)
            .ToList();

        return failures.Any()
            ? Errors(failures) as Task<TResponse>
            : next();
    }

    private CommandResponse Errors(IEnumerable<ValidationFailure> failures) {
        var response = new CommandResponse();

        foreach (var failure in failures)
            response.AddError(failure.ErrorMessage);
        
        _mediator.Publish(new ErrorNotification().AddErrors(response.Errors));

        return response;
    }
}
