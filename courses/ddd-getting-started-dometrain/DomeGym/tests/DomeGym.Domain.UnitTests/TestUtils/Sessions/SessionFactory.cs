using DomeGym.Domain.Common.ValueObjects;
using DomeGym.Domain.SessionAggregate;

namespace DomeGym.Domain.UnitTests.TestUtils.Sessions;

public static class SessionFactory {
    public static Session CreateSession(
        string name = Constants.Session.Name,
        string description = Constants.Session.Description,
        Guid? roomId = null,
        Guid? trainerId = null,
        int maxParticipants = Constants.Session.MaxParticipants,
        DateOnly? date = null,
        TimeRange? time = null,
        List<SessionCategory>? categories = null,
        Guid? id = null) {
        return new Session(
            name,
            description,
            maxParticipants,
            roomId ?? Constants.Room.Id,
            trainerId ?? Constants.Trainer.Id,
            date ?? Constants.Session.Date,
            time ?? Constants.Session.Time,
            categories ?? Constants.Session.Categories,
            id ?? Constants.Session.Id);
    }
}
