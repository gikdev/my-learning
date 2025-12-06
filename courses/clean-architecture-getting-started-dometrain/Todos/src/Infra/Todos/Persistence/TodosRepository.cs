using App.Common.Interfaces;
using Domain.Todos;
using Infra.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infra.Todos.Persistence;

public class TodosRepository(
    MainDbCtx db
) : ITodosRepository {
    public async Task AddAsync(Todo todo) {
        await db.Todos.AddAsync(todo);
    }

    public async Task<Todo?> GetByIdAsync(Guid id) {
        return await db.Todos
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public Task UpdateAsync(Todo todo) {
        db.Update(todo);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(Todo todo) {
        db.Remove(todo);
        return Task.CompletedTask;
    }

    public async Task<List<Todo>> ListAsync(
        Guid? categoryId = null,
        bool? isCompleted = null,
        TodoImportance? importance = null,
        string? searchQuery = null,
        CancellationToken cancellationToken = default
    ) {
        var query = db.Todos.AsQueryable();

        if (categoryId is not null)
            query = query.Where(t => t.CategoryId == categoryId);

        if (isCompleted is not null)
            query = query.Where(t => t.IsCompleted == isCompleted);

        if (importance is not null)
            query = query.Where(t => t.Importance == importance);

        if (!string.IsNullOrWhiteSpace(searchQuery))
            query = query.Where(t => t.Title.Contains(searchQuery));

        return await query.ToListAsync(cancellationToken);
    }
}
