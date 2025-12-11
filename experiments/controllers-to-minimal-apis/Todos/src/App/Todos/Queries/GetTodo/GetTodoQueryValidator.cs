using FluentValidation;

namespace App.Todos.Queries.GetTodo;

public class GetTodoQueryValidator : AbstractValidator<GetTodoQuery> {
    public GetTodoQueryValidator() {
        RuleFor(x => x.TodoId)
            .NotEmpty();
    }
}

