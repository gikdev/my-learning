using Dapper;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;
using GymManagement.Infrastructure.Common.Persistence;

namespace GymManagement.Infrastructure.Subscriptions.Persistence;

public class SubscriptionsRepository(
    GymManagementDbContext db,
    IDbConnectionFactory dbConnectionFactory
) : ISubscriptionsRepository {

    public async Task AddSubscriptionAsync(Subscription subscription) {
        await db.AddAsync(subscription);
    }

    public async Task<Subscription?> GetByIdAsync(Guid subscriptionId) {
        using var connection = await dbConnectionFactory.CreateConnectionAsync();

        var command = new CommandDefinition("""
            SELECT "Id", "SubscriptionType", "AdminId"
            FROM "Subscriptions"
            WHERE "Id" = @Id;
        """, new { Id = subscriptionId });

        return await connection.QuerySingleOrDefaultAsync<Subscription>(command);
    }
}
