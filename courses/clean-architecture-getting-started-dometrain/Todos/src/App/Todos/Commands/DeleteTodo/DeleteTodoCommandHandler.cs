using App.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace App.Todos.Commands.DeleteTodo;

public class DeleteTodoCommandHandler(
    ITodosRepository todosRepository,
    ICategoriesRepository categoriesRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<DeleteTodoCommand, ErrorOr<Deleted>> {
    public async Task<ErrorOr<Deleted>> Handle(DeleteTodoCommand request, CancellationToken cancellationToken) {
        var todo = await todosRepository.GetByIdAsync(request.TodoId);
        if (todo is null) return Error.NotFound(description: "Todo not found");

        if (todo.CategoryId is { } categoryId) {
            var category = await categoriesRepository.GetByIdAsync(categoryId);
            if (category is null) return Error.NotFound(description: "Category not found");

            category.RemoveTodo(todo);
            await categoriesRepository.UpdateAsync(category);
        }

        await todosRepository.RemoveAsync(todo);
        await unitOfWork.CommitChangesAsync();

        return Result.Deleted;
    }
}
