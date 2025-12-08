using Domain.Common.Interfaces;

namespace UnitTest.TestUtils.Services;

public class TestDateTimeProvider(DateTime? fixedDateTime = null) : IDateTimeProvider {
    public DateTime UtcNow => fixedDateTime ?? DateTime.UtcNow;
}
