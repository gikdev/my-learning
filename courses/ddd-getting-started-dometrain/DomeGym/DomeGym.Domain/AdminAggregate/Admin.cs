using DomeGym.Domain.Common;

namespace DomeGym.Domain.AdminAggregate;

public class Admin : AggregateRoot {
    private readonly Guid _subscriptionId;
    private readonly Guid _userId;

    public Admin(
        Guid userId,
        Guid subscriptionId,
        Guid? id = null)
        : base(id ?? Guid.NewGuid()) {
        _userId = userId;
        _subscriptionId = subscriptionId;
    }
}
