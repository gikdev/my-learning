namespace DomeGym.Domain.UnitTests.TestConstants;

public static partial class Constants {
    public static class Room {
        public const int MaxDailySessions = Subscriptions.MaxDailySessionsFreeTier;
        public static readonly Guid Id = Guid.NewGuid();
    }
}
