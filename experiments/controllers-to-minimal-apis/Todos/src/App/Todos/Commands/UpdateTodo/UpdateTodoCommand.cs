using ErrorOr;
using MediatR;
using Domain.Todos;

namespace App.Todos.Commands.UpdateTodo;

public record UpdateTodoCommand(
    Guid TodoId,
    string? NewTitle = null,
    TodoImportance? Importance = null,
    bool? Completed = null
) : IRequest<ErrorOr<Success>>;
