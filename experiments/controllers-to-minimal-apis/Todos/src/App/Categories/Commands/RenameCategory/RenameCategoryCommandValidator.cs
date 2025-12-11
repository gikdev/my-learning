using FluentValidation;

namespace App.Categories.Commands.RenameCategory;

public class RenameCategoryCommandValidator : AbstractValidator<RenameCategoryCommand> {
    public RenameCategoryCommandValidator() {
        RuleFor(x => x.CategoryId)
            .NotEmpty();

        RuleFor(x => x.NewTitle)
            .MinimumLength(1)
            .MaximumLength(100);
    }
}

