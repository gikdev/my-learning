using ErrorOr;

namespace GymManagement.Domain.Subscriptions;

public static class SubscriptionErrors {
    public static readonly Error CannotHaveMoreGymsThanTheSubscriptionAllows = Error.Validation(
        "Subscription.CannotHaveMoreGymsThanTheSubscriptionAllows",
        "A subscription cannot have more gyms than the subscription allows");
}
