using Domain;

namespace UnitTest.TestUtils.Services;

public class TestDateTimeProvider(DateTime? fixedDateTime = null) : IDateTimeProvider {
    public DateTime UtcNow => fixedDateTime ?? DateTime.UtcNow;
}
