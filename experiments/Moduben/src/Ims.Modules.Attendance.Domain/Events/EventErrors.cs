using Ims.Common.Domain;

namespace Ims.Modules.Attendance.Domain.Events;

public static class EventErrors {
    public static Error NotFound(Guid eventId) {
        return Error.NotFound("Events.NotFound", $"The event with the identifier {eventId} was not found");
    }
}
