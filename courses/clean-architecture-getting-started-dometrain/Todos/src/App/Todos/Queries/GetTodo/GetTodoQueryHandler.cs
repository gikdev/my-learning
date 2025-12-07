using App.Common.Interfaces;
using Domain.Todos;
using ErrorOr;
using MediatR;

namespace App.Todos.Queries.GetTodo;

public class GetTodoQueryHandler(
    ITodosRepository todosRepository
) : IRequestHandler<GetTodoQuery, ErrorOr<Todo>> {
    public async Task<ErrorOr<Todo>> Handle(GetTodoQuery request, CancellationToken cancellationToken) {
        var todo = await todosRepository.GetByIdAsync(request.TodoId);
        if (todo is null) return Error.NotFound(description: "Todo not found");

        return todo;
    }
}
