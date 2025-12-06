using System.Reflection;
using App.Common.Interfaces;
using Domain.Categories;
using Domain.Todos;
using Microsoft.EntityFrameworkCore;

namespace Infra.Common.Persistence;

public class MainDbCtx(DbContextOptions options) : DbContext(options), IUnitOfWork {
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Todo> Todos => Set<Todo>();

    public async Task CommitChangesAsync() {
        await SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
