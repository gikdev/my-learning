using FluentAssertions;
using Ims.Common.Domain;
using Ims.Modules.Ticketing.Application.Events.CancelEvent;
using Ims.Modules.Ticketing.Domain.Events;
using Ims.Modules.Ticketing.IntegrationTests.Abstractions;

namespace Ims.Modules.Ticketing.IntegrationTests.Events;

public class CancelEventTests : BaseIntegrationTest {
    private const decimal Quantity = 10;

    public CancelEventTests(IntegrationTestWebAppFactory factory)
        : base(factory) { }

    [Fact]
    public async Task Should_ReturnFailure_WhenEventDoesNotExist() {
        //Arrange
        var eventId = Guid.NewGuid();

        var command = new CancelEventCommand(eventId);

        //Act
        Result result = await Sender.Send(command);

        //Assert
        result.Error.Should().Be(EventErrors.NotFound(command.EventId));
    }

    [Fact]
    public async Task Should_ReturnSuccess_WhenEventIsCanceled() {
        //Arrange
        var eventId      = Guid.NewGuid();
        var ticketTypeId = Guid.NewGuid();

        await Sender.CreateEventWithTicketTypeAsync(eventId, ticketTypeId, Quantity);

        var command = new CancelEventCommand(eventId);

        //Act
        Result result = await Sender.Send(command);

        //Assert
        result.IsSuccess.Should().BeTrue();
    }
}
