using DevHabit.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevHabit.Api.Database;

public sealed class AppDbCtx(DbContextOptions<AppDbCtx> options) : DbContext(options)
{
    public DbSet<Habit> Habits { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Application);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbCtx).Assembly);
    }
}
