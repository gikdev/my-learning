using App.Common.Interfaces;
using Domain.Todos;
using ErrorOr;
using MediatR;

namespace App.Todos.Queries.ListTodos;

public class ListTodosQueryHandler(
    ITodosRepository todosRepository
) : IRequestHandler<ListTodosQuery, ErrorOr<IEnumerable<Todo>>> {
    public async Task<ErrorOr<IEnumerable<Todo>>> Handle(ListTodosQuery request, CancellationToken cancellationToken) {
        var todos = await todosRepository.ListAsync(
            request.CategoryId,
            request.IsCompleted,
            request.Importance,
            request.SearchQuery,
            cancellationToken
        );

        return todos;
    }
}
