using Domain.Todos;
using ErrorOr;
using MediatR;

namespace App.Todos.Commands.CreateTodo;

public record CreateTodoCommand(
    string Title,
    TodoImportance? Importance = null
) : IRequest<ErrorOr<Todo>>;
