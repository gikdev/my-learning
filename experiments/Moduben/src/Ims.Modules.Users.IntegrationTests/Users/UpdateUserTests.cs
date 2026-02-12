using FluentAssertions;
using Ims.Common.Domain;
using Ims.Modules.Users.Application.Users.RegisterUser;
using Ims.Modules.Users.Application.Users.UpdateUser;
using Ims.Modules.Users.Domain.Users;
using Ims.Modules.Users.IntegrationTests.Abstractions;

namespace Ims.Modules.Users.IntegrationTests.Users;

public class UpdateUserTests : BaseIntegrationTest {
    public static readonly TheoryData<UpdateUserCommand> InvalidCommands = new() {
        new UpdateUserCommand(Guid.Empty,     Faker.Name.FirstName(), Faker.Name.LastName()),
        new UpdateUserCommand(Guid.NewGuid(), "",                     Faker.Name.LastName()),
        new UpdateUserCommand(Guid.NewGuid(), Faker.Name.FirstName(), "")
    };

    public UpdateUserTests(IntegrationTestWebAppFactory factory)
        : base(factory) { }

    [Theory]
    [MemberData(nameof(InvalidCommands))]
    public async Task Should_ReturnError_WhenCommandIsNotValid(UpdateUserCommand command) {
        // Act
        Result result = await Sender.Send(command);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Type.Should().Be(ErrorType.Validation);
    }

    [Fact]
    public async Task Should_ReturnError_WhenUserDoesNotExist() {
        // Arrange
        var userId = Guid.NewGuid();

        // Act
        Result updateResult = await Sender.Send(
            new UpdateUserCommand(userId, Faker.Name.FirstName(), Faker.Name.LastName()));

        // Assert
        updateResult.Error.Should().Be(UserErrors.NotFound(userId));
    }

    [Fact]
    public async Task Should_ReturnSuccess_WhenUserExists() {
        // Arrange
        Result<Guid> result = await Sender.Send(new RegisterUserCommand(
            Faker.Internet.Email(),
            Faker.Internet.Password(),
            Faker.Name.FirstName(),
            Faker.Name.LastName()));

        Guid userId = result.Value;

        // Act
        Result updateResult = await Sender.Send(
            new UpdateUserCommand(userId, Faker.Name.FirstName(), Faker.Name.LastName()));

        // Assert
        updateResult.IsSuccess.Should().BeTrue();
    }
}
