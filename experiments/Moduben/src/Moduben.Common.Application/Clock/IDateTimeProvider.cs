namespace Moduben.Common.Application.Clock;

public interface IDateTimeProvider {
    DateTime UtcNow { get; }
}
