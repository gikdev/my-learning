using FluentValidation;

namespace TaskForge.Application.Labels.Commands.UpdateLabel;

public class UpdateLabelValidator : AbstractValidator<UpdateLabelCommand> {
    public UpdateLabelValidator() {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.NewTitle)
            .MinimumLength(1)
            .WithMessage("Title shouldn't be empty!");
    }
}
