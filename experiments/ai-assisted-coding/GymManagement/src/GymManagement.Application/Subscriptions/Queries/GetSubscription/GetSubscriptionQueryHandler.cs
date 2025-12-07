using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;
using MediatR;

namespace GymManagement.Application.Subscriptions.Queries.GetSubscription;

public class GetSubscriptionQueryHandler(
    ISubscriptionsRepository subscriptionsRepository
) : IRequestHandler<GetSubscriptionQuery, ErrorOr<Subscription>> {
    public async Task<ErrorOr<Subscription>> Handle(GetSubscriptionQuery request, CancellationToken cancellationToken) {
        var subscription = await subscriptionsRepository.GetByIdAsync(request.SubscriptionId);
        return subscription is null ? Error.NotFound(description: "Subscription not found") : subscription;
    }
}
