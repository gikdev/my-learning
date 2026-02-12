using FluentAssertions;
using Ims.Common.Domain;
using Ims.IntegrationTests.Abstractions;
using Ims.Modules.Attendance.Application.Attendees.GetAttendee;
using Ims.Modules.Users.Application.Users.RegisterUser;

namespace Ims.IntegrationTests.RegisterUser;

public sealed class RegisterUserTests : BaseIntegrationTest {
    public RegisterUserTests(IntegrationTestWebAppFactory factory)
        : base(factory) { }

    [Fact]
    public async Task RegisterUser_Should_PropagateToAttendanceModule() {
        // Register user
        var command = new RegisterUserCommand(
            Faker.Internet.Email(),
            Faker.Internet.Password(6),
            Faker.Name.FirstName(),
            Faker.Name.LastName());

        Result<Guid> userResult = await Sender.Send(command);

        userResult.IsSuccess.Should().BeTrue();

        // Get attendee
        Result<AttendeeResponse> attendeeResult = await Poller.WaitAsync(
            TimeSpan.FromSeconds(15),
            async () => {
                var query = new GetAttendeeQuery(userResult.Value);

                Result<AttendeeResponse> customerResult = await Sender.Send(query);

                return customerResult;
            });

        // Assert
        attendeeResult.IsSuccess.Should().BeTrue();
        attendeeResult.Value.Should().NotBeNull();
    }
}
