using FluentValidation;

namespace App.Todos.Commands.DeleteTodo;

public class DeleteTodoCommandValidator : AbstractValidator<DeleteTodoCommand> {
    public DeleteTodoCommandValidator() {
        RuleFor(x => x.TodoId)
            .NotEmpty();
    }
}

