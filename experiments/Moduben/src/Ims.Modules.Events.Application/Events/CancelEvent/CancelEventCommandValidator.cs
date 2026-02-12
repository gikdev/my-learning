using FluentValidation;

namespace Ims.Modules.Events.Application.Events.CancelEvent;

internal sealed class CancelEventCommandValidator : AbstractValidator<CancelEventCommand> {
    public CancelEventCommandValidator() {
        RuleFor(c => c.EventId).NotEmpty();
    }
}
