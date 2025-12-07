using GymManagement.Domain.Common;
using GymManagement.Infrastructure.Common.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace GymManagement.Infrastructure.Common.Middleware;

public class EventualConsistencyMiddleware(
    RequestDelegate next
) {
    public async Task InvokeAsync(HttpContext ctx, IPublisher publisher, GymManagementDbContext db) {
        var tx = await db.Database.BeginTransactionAsync();

        ctx.Response.OnCompleted(async () => {
            try {

                var contains = ctx.Items.TryGetValue("DomainEventsQueue", out var value);

                if (contains && value is Queue<IDomainEvent> domainEventsQueue)
                    while (domainEventsQueue.TryDequeue(out var domainEvent))
                        await publisher.Publish(domainEvent);

                await tx.CommitAsync();
            }
            catch {
                // notify user that something went wrong, although
                // it may not used to seem in the response they got
            }
            finally {
                await tx.DisposeAsync();
            }
        });

        await next(ctx);
    }
}
