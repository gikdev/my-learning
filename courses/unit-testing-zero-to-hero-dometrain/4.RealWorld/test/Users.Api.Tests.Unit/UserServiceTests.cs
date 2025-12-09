using FluentAssertions;
using Microsoft.Data.Sqlite;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;
using Users.Api.Logging;
using Users.Api.Models;
using Users.Api.Repositories;
using Users.Api.Services;

namespace Users.Api.Tests.Unit;

public class UserServiceTests {
    private readonly UserService _sut;
    private readonly IUserRepository _userRepository = Substitute.For<IUserRepository>();
    private readonly ILoggerAdapter<UserService> _logger = Substitute.For<ILoggerAdapter<UserService>>();

    public UserServiceTests() {
        _sut = new UserService(
            userRepository: _userRepository,
            logger: _logger
        );
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnEmptyList_WhenNoUsersExist() {
        // Arrange
        _userRepository.GetAllAsync().Returns([]);

        // Act
        var result = await _sut.GetAllAsync();

        // Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnUsers_WhenSomeUsersExist() {
        // Arrange
        var nickChapsas = new User {
            Id = Guid.NewGuid(),
            FullName = "Nick Chapsas",
        };
        var expectedUsers = new[] {
            nickChapsas,
        };
        _userRepository.GetAllAsync().Returns(expectedUsers);

        // Act
        var result = await _sut.GetAllAsync();

        // Assert
        result.Single().Should().BeEquivalentTo(nickChapsas);
        result.Should().BeEquivalentTo(expectedUsers);
    }

    [Fact]
    public async Task GetAllAsync_ShouldLogMessages_WhenInvoked() {
        // Arrange
        _userRepository.GetAllAsync().Returns([]);

        // Act
        await _sut.GetAllAsync();

        // Assert
        _logger.Received(1).LogInformation(Arg.Is("Retrieving all users"));
        _logger.Received(1).LogInformation(Arg.Is("All users retrieved in {0}ms"), Arg.Any<long>());
    }

    [Fact]
    public async Task GetAllAsync_ShouldLogMessageAndException_WhenExceptionIsThrown() {
        // Arrange
        var ex = new SqliteException("Something went wrong", 500);
        _userRepository.GetAllAsync()
            .Throws(ex);

        // Act
        var requestAction = async () => await _sut.GetAllAsync();

        // Assert
        await requestAction.Should()
            .ThrowAsync<SqliteException>()
            .WithMessage("Something went wrong");
        _logger.Received(1).LogError(Arg.Is(ex), Arg.Is("Something went wrong while retrieving all users"));
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnAUser_WhenAUserExists() {
        // Arrange
        var userId = Guid.NewGuid();
        var user = new User {
            FullName = "Pat",
            Id = userId,
        };
        _userRepository.GetByIdAsync(userId).Returns(user);

        // Act
        var result = await _sut.GetByIdAsync(userId);

        // Assert
        result.Should().BeEquivalentTo(user);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnNull_WhenNoUsersExist() {
        // Arrange
        var userId = Guid.NewGuid();
        _userRepository.GetByIdAsync(userId).ReturnsNull();

        // Act
        var result = await _sut.GetByIdAsync(userId);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task GetByIdAsync_ShouldLogTheCorrectMessages_WhenRetrievingTheUsers() {
        // Arrange
        var userId = Guid.NewGuid();
        var user = new User {
            FullName = "Pat",
            Id = userId,
        };
        _userRepository.GetByIdAsync(userId).Returns(user);

        // Act
        await _sut.GetByIdAsync(userId);

        // Assert
        _logger.Received(1).LogInformation(Arg.Is("Retrieving user with id: {0}"), Arg.Is(userId));
        _logger.Received(1).LogInformation(Arg.Is("User with id {0} retrieved in {1}ms"), Arg.Is(userId), Arg.Any<long>());
    }

    [Fact]
    public async Task GetByIdAsync_ShouldLogTheCorrectMessages_WhenAnExceptionIsThrown() {
        // Arrange
        var userId = Guid.NewGuid();
        var ex = new SqliteException("Something went wrong", 500);
        _userRepository.GetByIdAsync(userId).Throws(ex);

        // Act
        var requestAction = async () => await _sut.GetByIdAsync(userId);

        // Assert
        await requestAction.Should()
            .ThrowAsync<SqliteException>()
            .WithMessage("Something went wrong");
        _logger.Received(1).LogError(Arg.Is(ex), Arg.Is("Something went wrong while retrieving user with id {0}"), Arg.Is(userId));
    }

    [Fact]
    public async Task CreateAsync_ShouldCreateAUser_WhenUserCreateDetailsAreValid() {
        // Arrange
        var userId = Guid.NewGuid();
        var user = new User {
            FullName = "Pat",
            Id = userId,
        };
        _userRepository.CreateAsync(user).Returns(true);

        // Act
        var result = await _sut.CreateAsync(user);

        // Assert
        result.Should().Be(true);
    }

    [Fact]
    public async Task CreateAsync_ShouldLogTheCorrectMessages_WhenCreatingAUser() {
        // Arrange
        var user = new User {
            FullName = "Pat",
            Id = Guid.NewGuid(),
        };
        _userRepository.CreateAsync(user).Returns(true);

        // Act
        await _sut.CreateAsync(user);

        // Assert
        _logger.Received(1).LogInformation(Arg.Is("Creating user with id {0} and name: {1}"), Arg.Is(user.Id), Arg.Is(user.FullName));
        _logger.Received(1).LogInformation(Arg.Is("User with id {0} created in {1}ms"), Arg.Is(user.Id), Arg.Any<long>());
    }

    [Fact]
    public async Task CreateAsync_ShouldLogTheCorrectMessages_WhenAnExceptionIsThrown() {
        // Arrange
        var ex = new SqliteException("Something went wrong", 500);
        var user = new User {
            FullName = "Pat",
            Id = Guid.NewGuid(),
        };
        _userRepository.CreateAsync(user).Throws(ex);

        // Act
        var action = async () => await _sut.CreateAsync(user);

        // Assert
        await action.Should()
            .ThrowAsync<SqliteException>()
            .WithMessage("Something went wrong");
        _logger.Received(1).LogError(Arg.Is(ex), Arg.Is("Something went wrong while creating a user"));
    }

    [Fact]
    public async Task DeleteByIdAsync_ShouldDeleteAUser_WhenTheUserExists() {
        // Given
        var userId = Guid.NewGuid();
        _userRepository.DeleteByIdAsync(userId).Returns(true);

        // When
        var result = await _sut.DeleteByIdAsync(userId);

        // Then
        result.Should().Be(true);
    }

    [Fact]
    public async Task DeleteByIdAsync_ShouldNotDeleteAUser_WhenTheyDontExist() {
        // Given
        var fakeId = Guid.NewGuid();
        _userRepository.DeleteByIdAsync(fakeId).Returns(false);

        // When
        var result = await _sut.DeleteByIdAsync(fakeId);

        // Then
        result.Should().Be(false);
    }

    [Fact]
    public async Task DeleteByIdAsync_ShouldLogTheCorrectMessages_WhenDeletingAUser() {
        // Given
        var userId = Guid.NewGuid();
        _userRepository.DeleteByIdAsync(userId).Returns(true);

        // When
        await _sut.DeleteByIdAsync(userId);

        // Then
        _logger.Received(1).LogInformation(Arg.Is("Deleting user with id: {0}"), Arg.Is(userId));
        _logger.Received(1).LogInformation(Arg.Is("User with id {0} deleted in {1}ms"), Arg.Is(userId), Arg.Any<long>());
    }

    [Fact]
    public async Task DeleteByIdAsync_ShouldLogTheCorrectMessages_WhenAnExceptionIsThrown() {
        // Given
        var ex = new SqliteException("Something went wrong.", 500);
        var userId = Guid.NewGuid();
        _userRepository.DeleteByIdAsync(userId).Throws(ex);

        // When
        var action = async () => await _sut.DeleteByIdAsync(userId);

        // Then
        await action.Should()
            .ThrowAsync<SqliteException>()
            .WithMessage("Something went wrong.");
        _logger.Received(1).LogInformation(Arg.Is("Deleting user with id: {0}"), Arg.Is(userId));
        _logger.Received(1).LogInformation(Arg.Is("User with id {0} deleted in {1}ms"), Arg.Is(userId), Arg.Any<long>());
    }

    // [Fact(Skip = "Not implemented yet.")]
    // public async Task This_Should_When() { }
}
