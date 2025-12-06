using FluentValidation;

namespace App.Categories.Commands.RemoveTodoFromCategory;

public class RemoveTodoFromCategoryCommandValidator : AbstractValidator<RemoveTodoFromCategoryCommand> {
    public RemoveTodoFromCategoryCommandValidator() {
        RuleFor(x => x.CategoryId)
            .NotEmpty();

        RuleFor(x => x.TodoId)
            .NotEmpty();
    }
}

