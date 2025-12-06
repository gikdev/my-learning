using Domain.Todos;

namespace App.Common.Interfaces;

public interface ITodosRepository {
    Task AddAsync(Todo todo);

    // Task<bool> ExistsAsync(Guid id);
    Task<Todo?> GetByIdAsync(Guid id);
    Task UpdateAsync(Todo todo);
    Task RemoveAsync(Todo todo);

    Task<List<Todo>> ListAsync(
        Guid? categoryId = null,
        bool? isCompleted = null,
        TodoImportance? importance = null,
        string? searchQuery = null,
        CancellationToken cancellationToken = default
    );
}
