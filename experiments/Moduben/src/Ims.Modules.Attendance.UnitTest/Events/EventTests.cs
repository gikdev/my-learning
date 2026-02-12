using FluentAssertions;
using Ims.Common.Domain;
using Ims.Modules.Attendance.Domain.Events;
using Ims.Modules.Attendance.UnitTests.Abstractions;

namespace Ims.Modules.Attendance.UnitTests.Events;

public class EventTests : BaseTest {
    [Fact]
    public void Should_RaiseDomainEvent_WhenEventCreated() {
        //Arrange
        var      eventId     = Guid.NewGuid();
        DateTime startsAtUtc = DateTime.Now;

        //Act
        Result<Event> result = Event.Create(
            eventId,
            Faker.Music.Genre(),
            Faker.Music.Genre(),
            Faker.Address.StreetAddress(),
            startsAtUtc,
            null);

        //Assert
        EventCreatedDomainEvent domainEvent =
            AssertDomainEventWasPublished<EventCreatedDomainEvent>(result.Value);

        domainEvent.EventId.Should().Be(result.Value.Id);
    }
}
