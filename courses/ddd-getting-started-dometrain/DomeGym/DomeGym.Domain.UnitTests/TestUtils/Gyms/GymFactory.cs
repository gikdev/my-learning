using DomeGym.Domain.GymAggregate;

namespace DomeGym.Domain.UnitTests.TestUtils.Gyms;

public static class GymFactory {
    public static Gym CreateGym(
        int maxRooms = Constants.Subscriptions.MaxRoomsFreeTier,
        Guid? id = null) {
        return new Gym(
            maxRooms,
            Constants.Subscriptions.Id,
            id ?? Constants.Gym.Id);
    }
}
