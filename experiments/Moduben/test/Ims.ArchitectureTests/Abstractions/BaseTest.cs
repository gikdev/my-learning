namespace Ims.ArchitectureTests.Abstractions;

#pragma warning disable CA1515
public abstract class BaseTest {
    protected const string UsersNamespace                  = "Ims.Modules.Users";
    protected const string UsersIntegrationEventsNamespace = "Ims.Modules.Users.IntegrationEvents";

    protected const string EventsNamespace                  = "Ims.Modules.Events";
    protected const string EventsIntegrationEventsNamespace = "Ims.Modules.Events.IntegrationEvents";

    protected const string TicketingNamespace                  = "Ims.Modules.Ticketing";
    protected const string TicketingIntegrationEventsNamespace = "Ims.Modules.Ticketing.IntegrationEvents";

    protected const string AttendanceNamespace                  = "Ims.Modules.Attendance";
    protected const string AttendanceIntegrationEventsNamespace = "Ims.Modules.Attendance.IntegrationEvents";
#pragma warning restore CA1515
}
