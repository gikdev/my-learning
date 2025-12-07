namespace GymManagement.Contracts.Subscriptions;

public record SubscriptionResponse(
  Guid Id,
  SubscriptionType SubscriptionType
) {
    public static implicit operator Guid(SubscriptionResponse v) {
        throw new NotImplementedException();
    }
}
