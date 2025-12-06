using Domain.Todos;
using FluentValidation;

namespace App.Todos.Commands.CreateTodo;

public class CreateTodoCommandValidator : AbstractValidator<CreateTodoCommand> {
    public CreateTodoCommandValidator() {
        RuleFor(o => o.Title)
            .MinimumLength(1)
            .MaximumLength(100);

        RuleFor(o => o.Importance)
            .Must(i => i == null || TodoImportance.List.Contains(i))
            .WithMessage("Invalid importance value");
    }
}
