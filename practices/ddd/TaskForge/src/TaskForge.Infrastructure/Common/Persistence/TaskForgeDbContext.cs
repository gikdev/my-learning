using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TaskForge.Domain.LabelAggregate;
using TaskForge.Domain.ProjectAggregate;

namespace TaskForge.Infrastructure.Common.Persistence;

public class TaskForgeDbContext(
    DbContextOptions options
) : DbContext(options) {
    public DbSet<Label> Labels => Set<Label>();
    public DbSet<Project> Projects => Set<Project>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
