using Domain.Todos;
using ErrorOr;
using MediatR;

namespace App.Todos.Queries.GetTodo;

public class GetTodoQueryHandler : IRequestHandler<GetTodoQuery, ErrorOr<Todo>> {
    public Task<ErrorOr<Todo>> Handle(GetTodoQuery request, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}
