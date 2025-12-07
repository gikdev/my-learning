using System.Threading.Tasks;
using FluentAssertions;
using GymManagement.Application.SubcutaneousTests.Common;
using GymManagement.Application.Subscriptions.Commands.CreateSubscription;
using MediatR;
using TestCommon.Gyms;
using TestCommon.TestConstants;

namespace GymManagement.Application.SubcutaneousTests.Gyms.Commands;

[Collection(MediatorFactoryCollection.CollectionName)]
public class CreateGymTests(MediatorFactory mediatorFactory) {
    private readonly IMediator _mediator = mediatorFactory.CreateMediator();

    [Fact]
    public async Task CreateGym_WhenValidCommand_ShouldCreateGym() {
        // Arrange
        var createSubscriptionCommand = new CreateSubscriptionCommand(
            Constants.Subscriptions.DefaultSubscriptionType,
            Constants.Admin.Id
        );

        var result = await _mediator.Send(createSubscriptionCommand);

        result.IsError.Should().BeFalse();

        var createGymCommand = GymCommandFactory.CreateCreateGymCommand(subscriptionId: result.Value.Id);

        // Act
        // Assert
    }
}
