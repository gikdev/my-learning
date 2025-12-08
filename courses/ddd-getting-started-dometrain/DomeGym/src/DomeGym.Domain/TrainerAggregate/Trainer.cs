using DomeGym.Domain.Common;
using DomeGym.Domain.Common.Entities;
using DomeGym.Domain.Common.ValueObjects;
using DomeGym.Domain.SessionAggregate;
using ErrorOr;

namespace DomeGym.Domain.TrainerAggregate;

public class Trainer : AggregateRoot {
    private readonly Schedule _schedule = Schedule.Empty();
    private readonly List<Guid> _sessionIds = new();

    public Trainer(
        Guid userId,
        Schedule? schedule = null,
        Guid? id = null)
        : base(id ?? Guid.NewGuid()) {
        UserId = userId;
        _schedule = schedule ?? Schedule.Empty();
    }

    private Trainer() {
    }

    public Guid UserId { get; }

    public ErrorOr<Success> AddSessionToSchedule(Session session) {
        if (_sessionIds.Contains(session.Id))
            return Error.Conflict(description: "Session already exists in trainer's schedule");

        var bookTimeSlotResult = _schedule.BookTimeSlot(session.Date, session.Time);

        if (bookTimeSlotResult.IsError && bookTimeSlotResult.FirstError.Type == ErrorType.Conflict)
            return TrainerErrors.CannotHaveTwoOrMoreOverlappingSessions;

        _sessionIds.Add(session.Id);
        return Result.Success;
    }

    public bool IsTimeSlotFree(DateOnly date, TimeRange time) {
        return _schedule.CanBookTimeSlot(date, time);
    }

    public ErrorOr<Success> RemoveFromSchedule(Session session) {
        if (!_sessionIds.Contains(session.Id)) return Error.Conflict("Trainer already assigned to teach session");

        var removeBookingResult = _schedule.RemoveBooking(
            session.Date,
            session.Time);

        if (removeBookingResult.IsError) return removeBookingResult.Errors;

        _sessionIds.Remove(session.Id);
        return Result.Success;
    }
}
