using FluentValidation;

namespace App.Todos.Commands.ToggleTodoCompleted;

public class ToggleTodoCompletedCommandValidator : AbstractValidator<ToggleTodoCompletedCommand> {
    public ToggleTodoCompletedCommandValidator() {
        RuleFor(x => x.TodoId)
            .NotEmpty();
    }
}

