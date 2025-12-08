using Domain.Common;
using Domain.Common.Interfaces;
using Domain.Common.ValueObjects;
using Domain.ParticipantAggregate;
using ErrorOr;

namespace Domain.SessionAggregate;

public class Session : AggregateRoot {
    private readonly Guid _trainerId;
    private readonly List<Reservation> _reservations = [];
    private readonly int _maxParticipants;

    public DateOnly Date { get; }

    public TimeRange Time { get; }

    public Session(
        DateOnly date,
        TimeRange time,
        int maxParticipants,
        Guid trainerId,
        Guid? id = null
    ) : base(id ?? Guid.NewGuid()) {
        Date = date;
        Time = time;
        _maxParticipants = maxParticipants;
        _trainerId = trainerId;
    }

    public ErrorOr<Success> CancelReservation(Participant participant, IDateTimeProvider dateTimeProvider) {
        if (IsTooCloseToSession(dateTimeProvider.UtcNow))
            return SessionErrors.CannotCancelReservationTooCloseToSession;

        var reservation = _reservations.FirstOrDefault(r => r.ParticipantId == participant.Id);
        if (reservation is null)
            return Error.NotFound(description: "Participant not found");

        _reservations.Remove(reservation);

        return Result.Success;
    }

    private bool IsTooCloseToSession(DateTime utcNow) {
        const int MinHours = 24;

        return (Date.ToDateTime(Time.Start) - utcNow).TotalHours < MinHours;
    }

    public ErrorOr<Success> ReserveSpot(Participant participant) {
        if (_reservations.Count >= _maxParticipants)
            return SessionErrors.CannotHaveMoreReservationsThanParticipants;

        if (_reservations.Any(r => r.ParticipantId == participant.Id))
            return Error.Conflict(description: "Participants cannot reserve twice to the same session");

        var newReservation = new Reservation(participant.Id);

        _reservations.Add(newReservation);

        return Result.Success;
    }
}
