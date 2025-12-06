using App.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace App.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler(
    ICategoriesRepository categoriesRepository,
    ITodosRepository todosRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<DeleteCategoryCommand, ErrorOr<Success>> {
    public async Task<ErrorOr<Success>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken) {
        var category = await categoriesRepository.GetByIdAsync(request.CategoryId);
        if (category is null) return Error.NotFound(description: "Category not found");

        foreach (var todoId in category.TodoIds) {
            var todo = await todosRepository.GetByIdAsync(todoId);
            if (todo is null) continue;
            todo.RemoveCategory();
            await todosRepository.UpdateAsync(todo);
        }

        await categoriesRepository.RemoveAsync(category);
        await unitOfWork.CommitChangesAsync();

        return Result.Success;
    }
}
