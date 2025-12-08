using DomeGym.Domain.Common;
using DomeGym.Domain.GymAggregate;
using ErrorOr;

namespace DomeGym.Domain.SubscriptionAggregate;

public class Subscription : AggregateRoot {
    private readonly Guid _adminId;
    private readonly List<Guid> _gymIds = new();
    private readonly int _maxGyms;

    public Subscription(
        SubscriptionType subscriptionType,
        Guid adminId,
        Guid? id = null)
        : base(id ?? Guid.NewGuid()) {
        SubscriptionType = subscriptionType;
        _maxGyms = GetMaxGyms();
        _adminId = adminId;
    }

    private Subscription() {
    }

    public SubscriptionType SubscriptionType { get; } = default!;

    public int GetMaxGyms() {
        return SubscriptionType.Name switch {
            nameof(SubscriptionType.Free) => 1,
            nameof(SubscriptionType.Starter) => 1,
            nameof(SubscriptionType.Pro) => 3,
            _ => throw new InvalidOperationException()
        };
    }

    public int GetMaxRooms() {
        return SubscriptionType.Name switch {
            nameof(SubscriptionType.Free) => 1,
            nameof(SubscriptionType.Starter) => 3,
            nameof(SubscriptionType.Pro) => int.MaxValue,
            _ => throw new InvalidOperationException()
        };
    }

    public int GetMaxDailySessions() {
        return SubscriptionType.Name switch {
            nameof(SubscriptionType.Free) => 4,
            nameof(SubscriptionType.Starter) => int.MaxValue,
            nameof(SubscriptionType.Pro) => int.MaxValue,
            _ => throw new InvalidOperationException()
        };
    }

    public ErrorOr<Success> AddGym(Gym gym) {
        if (_gymIds.Contains(gym.Id)) return Error.Conflict(description: "Gym already exists");

        if (_gymIds.Count >= _maxGyms) return SubscriptionErrors.CannotHaveMoreGymsThanSubscriptionAllows;

        _gymIds.Add(gym.Id);

        return Result.Success;
    }

    public bool HasGym(Guid gymId) {
        return _gymIds.Contains(gymId);
    }
}
