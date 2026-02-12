using FluentValidation;

namespace Ims.Modules.Attendance.Application.Attendees.CheckInAttendee;

internal sealed class CheckInAttendeeCommandValidator : AbstractValidator<CheckInAttendeeCommand> {
    public CheckInAttendeeCommandValidator() {
        RuleFor(c => c.TicketId).NotEmpty();
    }
}
