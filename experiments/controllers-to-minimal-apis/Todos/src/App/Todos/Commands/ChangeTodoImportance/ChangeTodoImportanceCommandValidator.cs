using Domain.Todos;
using FluentValidation;

namespace App.Todos.Commands.ChangeTodoImportance;

public class ChangeTodoImportanceCommandValidator : AbstractValidator<ChangeTodoImportanceCommand> {
    public ChangeTodoImportanceCommandValidator() {
        RuleFor(x => x.TodoId)
            .NotEmpty();

        RuleFor(o => o.Importance)
            .Must(i => i == null || TodoImportance.List.Contains(i))
            .WithMessage("Invalid importance value");
    }
}
