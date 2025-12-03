using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;
using GymManagement.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Infrastructure.Subscriptions.Persistence;

public class SubscriptionsRepository(
    GymManagementDbContext db
) : ISubscriptionsRepository {

    public async Task AddSubscriptionAsync(Subscription subscription) {
        await db.AddAsync(subscription);
    }

    public async Task<Subscription?> GetByIdAsync(Guid subscriptionId) {
        var subscription = await db.Subscriptions.FirstOrDefaultAsync(s => s.Id == subscriptionId);
        return subscription;
    }
}
