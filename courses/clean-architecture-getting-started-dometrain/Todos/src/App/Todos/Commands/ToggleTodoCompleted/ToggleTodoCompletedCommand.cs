using ErrorOr;
using MediatR;

namespace App.Todos.Commands.ToggleTodoCompleted;

public record ToggleTodoCompletedCommand(Guid TodoId) : IRequest<ErrorOr<Success>>;
