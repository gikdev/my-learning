using Ims.Common.Application.Messaging;

namespace Ims.Modules.Attendance.Application.Attendees.CreateAttendee;

public sealed record CreateAttendeeCommand(Guid AttendeeId, string Email, string FirstName, string LastName)
    : ICommand;
