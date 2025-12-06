using App.Common.Interfaces;
using Domain.Categories;
using Infra.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infra.Categories.Persistence;

public class CategoriesRepository(
    MainDbCtx db
) : ICategoriesRepository {
    public async Task AddAsync(Category category) {
        await db.Categories.AddAsync(category);
    }

    public async Task<Category?> GetByIdAsync(Guid id) {
        return await db.Categories
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Category>> ListAsync() {
        return await db.Categories.ToListAsync();
    }

    public Task UpdateAsync(Category category) {
        db.Update(category);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(Category category) {
        db.Remove(category);
        return Task.CompletedTask;
    }
}
