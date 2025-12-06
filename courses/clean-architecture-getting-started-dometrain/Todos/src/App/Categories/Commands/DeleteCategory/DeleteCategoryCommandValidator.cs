using FluentValidation;

namespace App.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand> {
    public DeleteCategoryCommandValidator() {
        RuleFor(x => x.CategoryId)
            .NotEmpty();
    }
}

