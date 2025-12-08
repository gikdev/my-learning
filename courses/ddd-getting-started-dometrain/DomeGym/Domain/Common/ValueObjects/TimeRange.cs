using ErrorOr;
using Throw;

namespace Domain.Common.ValueObjects;

public class TimeRange : ValueObject {
    public TimeOnly Start { get; init; }
    public TimeOnly End { get; init; }

    public TimeRange(TimeOnly start, TimeOnly end) {
        start.Throw().IfGreaterThanOrEqualTo(end);

        Start = start;
        End = end;
    }

    public static ErrorOr<TimeRange> FromDateTimes(DateTime start, DateTime end) {
        if (start.Date != end.Date || start >= end)
            return Error.Validation("Start & end date times must be on the same day");

        if (start >= end)
            return Error.Validation("End time must be greater than the start time");

        var startTime = TimeOnly.FromDateTime(start);
        var endTime = TimeOnly.FromDateTime(end);

        return new TimeRange(startTime, endTime);
    }

    public bool OverlapsWith(TimeRange other) {
        if (Start >= other.End) return false;
        if (other.Start >= End) return false;

        return true;
    }

    public override IEnumerable<object?> GetEqualityComponents() {
        yield return Start;
        yield return End;
    }
}
