using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;
using GymManagement.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Infrastructure.Subscriptions.Persistence;

public class SubscriptionsRepository(GymManagementDbContext db) : ISubscriptionsRepository {
    public async Task AddSubscriptionAsync(Subscription subscription) {
        await db.Subscriptions.AddAsync(subscription);
    }

    public async Task<bool> ExistsAsync(Guid id) {
        return await db.Subscriptions
            .AsNoTracking()
            .AnyAsync(subscription => subscription.Id == id);
    }

    public async Task<Subscription?> GetByAdminIdAsync(Guid adminId) {
        return await db.Subscriptions
            .AsNoTracking()
            .FirstOrDefaultAsync(subscription => subscription.AdminId == adminId);
    }

    public async Task<Subscription?> GetByIdAsync(Guid id) {
        return await db.Subscriptions.FirstOrDefaultAsync(subscription => subscription.Id == id);
    }

    public async Task<List<Subscription>> ListAsync() {
        return await db.Subscriptions.ToListAsync();
    }

    public Task RemoveSubscriptionAsync(Subscription subscription) {
        db.Remove(subscription);

        return Task.CompletedTask;
    }

    public Task UpdateAsync(Subscription subscription) {
        db.Update(subscription);

        return Task.CompletedTask;
    }
}
