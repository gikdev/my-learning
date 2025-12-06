using ErrorOr;
using MediatR;

namespace App.Todos.Commands.CreateTodo;

public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, ErrorOr<Success>> {
    public Task<ErrorOr<Success>> Handle(CreateTodoCommand request, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}

