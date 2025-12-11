using FluentValidation;

namespace App.Categories.Commands.AddTodoToCategory;

public class AddTodoToCategoryCommandValidator : AbstractValidator<AddTodoToCategoryCommand> {
    public AddTodoToCategoryCommandValidator() {
        RuleFor(x => x.CategoryId)
            .NotEmpty();

        RuleFor(x => x.TodoId)
            .NotEmpty();
    }
}

