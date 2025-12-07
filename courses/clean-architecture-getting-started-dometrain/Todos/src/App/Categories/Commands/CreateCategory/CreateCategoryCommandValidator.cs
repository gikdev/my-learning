using FluentValidation;

namespace App.Categories.Commands.CreateCategory;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand> {
    public CreateCategoryCommandValidator() {
        RuleFor(x => x.Title)
            .MinimumLength(1)
            .MaximumLength(100);
    }
}

