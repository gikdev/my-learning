using Domain.Todos;
using FluentValidation;

namespace App.Todos.Commands.UpdateTodo;

public class UpdateTodoCommandValidator : AbstractValidator<UpdateTodoCommand> {
    public UpdateTodoCommandValidator() {
        RuleFor(x => x.TodoId)
            .NotEmpty();

        When(x => x.NewTitle is not null, () => {
            RuleFor(x => x.NewTitle)
                .MinimumLength(1)
                .MaximumLength(100);
        });

        When(x => x.Importance is not null, () => {
            RuleFor(x => x.Importance)
            .Must(i => TodoImportance.List.Contains(i))
                .WithMessage("Invalid importance value");
        });
    }
}
