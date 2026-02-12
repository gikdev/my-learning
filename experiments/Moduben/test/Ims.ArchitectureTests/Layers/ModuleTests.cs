using System.Reflection;
using Ims.ArchitectureTests.Abstractions;
using Ims.Modules.Attendance.Domain.Attendees;
using Ims.Modules.Attendance.Infrastructure;
using Ims.Modules.Events.Domain.TicketTypes;
using Ims.Modules.Events.Infrastructure;
using Ims.Modules.Users.Application;
using Ims.Modules.Users.Domain.Users;
using Ims.Modules.Users.Infrastructure;
using NetArchTest.Rules;

namespace Ims.ArchitectureTests.Layers;

public class ModuleTests : BaseTest {
    [Fact]
    public void UsersModule_ShouldNotHaveDependencyOn_AnyOtherModule() {
        string[] otherModules = [EventsNamespace, TicketingNamespace, AttendanceNamespace];

        string[] integrationEventsModules = [
            EventsIntegrationEventsNamespace,
            TicketingIntegrationEventsNamespace,
            AttendanceIntegrationEventsNamespace
        ];

        List<Assembly> usersAssemblies = [
            typeof(User).Assembly,
            AssemblyReference.Assembly,
            Modules.Users.Presentation.AssemblyReference.Assembly,
            typeof(UsersModule).Assembly
        ];

        Types.InAssemblies(usersAssemblies)
            .That()
            .DoNotHaveDependencyOnAny(integrationEventsModules)
            .Should()
            .NotHaveDependencyOnAny(otherModules)
            .GetResult()
            .ShouldBeSuccessful();
    }

    [Fact]
    public void EventsModule_ShouldNotHaveDependencyOn_AnyOtherModule() {
        string[] otherModules = [UsersNamespace, TicketingNamespace, AttendanceNamespace];

        string[] integrationEventsModules = [
            UsersIntegrationEventsNamespace,
            TicketingIntegrationEventsNamespace,
            AttendanceIntegrationEventsNamespace
        ];

        List<Assembly> eventsAssemblies = [
            typeof(TicketType).Assembly,
            Modules.Events.Application.AssemblyReference.Assembly,
            Modules.Events.Presentation.AssemblyReference.Assembly,
            typeof(EventsModule).Assembly
        ];

        Types.InAssemblies(eventsAssemblies)
            .That()
            .DoNotHaveDependencyOnAny(integrationEventsModules)
            .Should()
            .NotHaveDependencyOnAny(otherModules)
            .GetResult()
            .ShouldBeSuccessful();
    }

    [Fact]
    public void AttendanceModule_ShouldNotHaveDependencyOn_AnyOtherModule() {
        string[] otherModules = [UsersNamespace, EventsNamespace, TicketingNamespace];

        string[] integrationEventsModules = [
            UsersIntegrationEventsNamespace,
            EventsIntegrationEventsNamespace,
            TicketingIntegrationEventsNamespace
        ];

        List<Assembly> attendanceAssemblies = [
            typeof(Attendee).Assembly,
            Modules.Attendance.Application.AssemblyReference.Assembly,
            Modules.Attendance.Presentation.AssemblyReference.Assembly,
            typeof(AttendanceModule).Assembly
        ];

        Types.InAssemblies(attendanceAssemblies)
            .That()
            .DoNotHaveDependencyOnAny(integrationEventsModules)
            .Should()
            .NotHaveDependencyOnAny(otherModules)
            .GetResult()
            .ShouldBeSuccessful();
    }
}
