using Domain.Categories;

namespace App.Common.Interfaces;

public interface ICategoriesRepository {
    Task AddAsync(Category category);

    // Task<bool> ExistsAsync(Guid id);
    Task<Category?> GetByIdAsync(Guid id);
    Task<List<Category>> ListAsync();
    Task UpdateAsync(Category category);
    Task RemoveAsync(Category category);
}
