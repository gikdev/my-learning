using Domain.Todos;
using ErrorOr;
using MediatR;

namespace App.Todos.Commands.ChangeTodoImportance;

public record ChangeTodoImportanceCommand(
    Guid TodoId,
    TodoImportance Importance
) : IRequest<ErrorOr<Success>>;
