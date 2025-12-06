using FluentValidation;

namespace App.Todos.Commands.RenameTodo;

public class RenameTodoCommandValidator : AbstractValidator<RenameTodoCommand> {
    public RenameTodoCommandValidator() {
        RuleFor(x => x.TodoId)
            .NotEmpty();

        RuleFor(x => x.NewTitle)
            .MinimumLength(1)
            .MaximumLength(100);
    }
}

