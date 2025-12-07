using ErrorOr;
using FluentValidation;
using MediatR;

namespace GymManagement.Application.Common.Behaviors;

public class ValidationBehavior<TReq, TRes>(IValidator<TReq>? validator)
    : IPipelineBehavior<TReq, TRes>
    where TReq : IRequest<TRes>
    where TRes : IErrorOr {
    public async Task<TRes> Handle(
        TReq request,
        RequestHandlerDelegate<TRes> next,
        CancellationToken cancellationToken
    ) {
        if (validator is null) return await next(cancellationToken);

        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid) return await next(cancellationToken);

        var errors = validationResult.Errors
            .ConvertAll(e =>
                Error.Validation(code: e.PropertyName, description: e.ErrorMessage)
            );

        return (dynamic)errors;
    }
}
