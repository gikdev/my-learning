using FluentValidation;

namespace TaskForge.Application.Labels.Commands.CreateLabel;

public class CreateLabelValidator : AbstractValidator<CreateLabelCommand> {
    public CreateLabelValidator() {
        RuleFor(x => x.Title.Trim())
            .NotNull()
            .MinimumLength(1)
            .NotEmpty();
    }
}
