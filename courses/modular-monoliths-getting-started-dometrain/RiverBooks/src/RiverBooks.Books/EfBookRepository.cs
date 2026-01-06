using Microsoft.EntityFrameworkCore;

namespace RiverBooks.Books;

internal class EfBookRepository(BookDbContext db) : IBookRepository {
    public async Task<Book?> GetByIdAsync(Guid id) {
        return await db.Books.FindAsync(id);
    }

    public async Task<List<Book>> ListAsync() {
        return await db.Books.ToListAsync();
    }

    public Task AddAsync(Book book) {
        db.Add(book);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Book book) {
        db.Remove(book);
        return Task.CompletedTask;
    }

    public async Task SaveChangesAsync() {
        await db.SaveChangesAsync();
    }
}
