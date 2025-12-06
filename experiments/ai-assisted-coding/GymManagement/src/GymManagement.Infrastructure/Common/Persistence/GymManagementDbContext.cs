using System.Reflection;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Rooms;
using GymManagement.Domain.Subscriptions;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Infrastructure.Common.Persistence;

public class GymManagementDbContext(DbContextOptions<GymManagementDbContext> options)
    : DbContext(options), IUnitOfWork {
    public DbSet<Subscription> Subscriptions => Set<Subscription>();
    public DbSet<Room> Rooms => Set<Room>();

    public async Task CommitChangesAsync() {
        await base.SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
