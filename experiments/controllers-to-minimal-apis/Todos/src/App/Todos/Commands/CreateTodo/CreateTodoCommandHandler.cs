using App.Common.Interfaces;
using Domain.Todos;
using ErrorOr;
using MediatR;

namespace App.Todos.Commands.CreateTodo;

public class CreateTodoCommandHandler(
    ITodosRepository todosRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<CreateTodoCommand, ErrorOr<Todo>> {
    public async Task<ErrorOr<Todo>> Handle(CreateTodoCommand request, CancellationToken cancellationToken) {
        var newTodo = new Todo(request.Title, request.Importance);

        await todosRepository.AddAsync(newTodo);
        await unitOfWork.CommitChangesAsync();

        return newTodo;
    }
}
