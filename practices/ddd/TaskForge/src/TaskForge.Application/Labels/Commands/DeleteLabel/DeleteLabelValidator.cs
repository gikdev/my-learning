using FluentValidation;

namespace TaskForge.Application.Labels.Commands.DeleteLabel;

public class DeleteLabelValidator : AbstractValidator<DeleteLabelCommand> {
    public DeleteLabelValidator() {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}
