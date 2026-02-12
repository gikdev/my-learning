using FluentValidation;

namespace Ims.Modules.Ticketing.Application.Tickets.CreateTicketBatch;

internal sealed class CreateTicketBatchCommandValidator : AbstractValidator<CreateTicketBatchCommand> {
    public CreateTicketBatchCommandValidator() {
        RuleFor(c => c.OrderId).NotEmpty();
    }
}
