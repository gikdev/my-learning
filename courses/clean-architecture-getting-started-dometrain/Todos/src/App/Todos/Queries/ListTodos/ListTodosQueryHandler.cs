using Domain.Todos;
using ErrorOr;
using MediatR;

namespace App.Todos.Queries.ListTodos;

public class ListTodosQueryHandler : IRequestHandler<ListTodosQuery, ErrorOr<IEnumerable<Todo>>> {
    public Task<ErrorOr<IEnumerable<Todo>>> Handle(ListTodosQuery request, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}
