using FluentAssertions;
using Ims.Common.Domain;
using Ims.Modules.Ticketing.Application.Carts.ClearCart;
using Ims.Modules.Ticketing.Domain.Customers;
using Ims.Modules.Ticketing.IntegrationTests.Abstractions;

namespace Ims.Modules.Ticketing.IntegrationTests.Carts;

public class ClearCartTests : BaseIntegrationTest {
    public ClearCartTests(IntegrationTestWebAppFactory factory)
        : base(factory) { }

    [Fact]
    public async Task Should_ReturnFailure_WhenCustomerDoesNotExist() {
        //Arrange
        var command = new ClearCartCommand(Guid.NewGuid());

        //Act
        Result result = await Sender.Send(command);

        //Assert
        result.Error.Should().Be(CustomerErrors.NotFound(command.CustomerId));
    }

    [Fact]
    public async Task Should_ReturnSuccess_WhenCustomerExists() {
        //Arrange
        Guid customerId = await Sender.CreateCustomerAsync(Guid.NewGuid());

        var command = new ClearCartCommand(customerId);

        //Act
        Result result = await Sender.Send(command);

        //Assert
        result.IsSuccess.Should().BeTrue();
    }
}
