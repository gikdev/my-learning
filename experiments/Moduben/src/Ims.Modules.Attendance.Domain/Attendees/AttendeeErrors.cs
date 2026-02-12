using Ims.Common.Domain;

namespace Ims.Modules.Attendance.Domain.Attendees;

public static class AttendeeErrors {
    public static Error NotFound(Guid attendeeId) {
        return Error.NotFound("Attendees.NotFound", $"The attendee with the identifier {attendeeId} was not found");
    }
}
