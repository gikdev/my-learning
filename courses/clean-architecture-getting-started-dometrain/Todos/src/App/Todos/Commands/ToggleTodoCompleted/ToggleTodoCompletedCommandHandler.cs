using ErrorOr;
using MediatR;

namespace App.Todos.Commands.ToggleTodoCompleted;

public class ToggleTodoCompletedCommandHandler : IRequestHandler<ToggleTodoCompletedCommand, ErrorOr<Success>> {
    public Task<ErrorOr<Success>> Handle(ToggleTodoCompletedCommand request, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}

