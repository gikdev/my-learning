using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Users.Api.Contracts;
using Users.Api.Controllers;
using Users.Api.Mappers;
using Users.Api.Models;
using Users.Api.Services;

namespace Users.Api.Tests.Unit;

public class UserControllerTests {
    private readonly UserController sut;
    private readonly IUserService userService = Substitute.For<IUserService>();

    public UserControllerTests() {
        sut = new UserController(userService);
    }

    [Fact]
    public async Task GetById_ShouldReturnNotFound_WhenUserDoesntExist() {
        // Given
        userService.GetByIdAsync(Arg.Any<Guid>()).ReturnsNull();

        // When
        var result = (NotFoundResult)await sut.GetById(Guid.NewGuid());

        // Then
        result.StatusCode.Should().Be(404);
    }

    [Fact]
    public async Task GetAll_ShouldReturnEmptyList_WhenNoUsersExist() {
        // Given
        userService.GetAllAsync().Returns([]);

        // When
        var result = (OkObjectResult)await sut.GetAll();

        // Then
        result.StatusCode.Should().Be(200);
        result.Value.As<IEnumerable<UserResponse>>().Should().BeEmpty();
    }

    [Fact]
    public async Task GetAll_ShouldReturnUsersResponse_WhenUsersExist() {
        // Given
        var user = new User {
            FullName = "Harry Potter",
            Id = Guid.NewGuid(),
        };
        var users = new[] { user };
        var usersRes = users.Select(x => x.ToUserResponse());
        userService.GetAllAsync().Returns(users);

        // When
        var result = (OkObjectResult)await sut.GetAll();

        // Then
        result.StatusCode.Should().Be(200);
        result.Value.As<IEnumerable<UserResponse>>().Should().BeEquivalentTo(usersRes);
    }

    [Fact]
    public async Task Create_ShouldReturnUserResponse_WhenUserWasCreated() {
        // Given
        var req = new CreateUserRequest { FullName = "Batman" };
        var user = new User { FullName = req.FullName };
        userService.CreateAsync(Arg.Do<User>(x => user = x)).Returns(true);
        var userRes = user.ToUserResponse();

        // When
        var result = (CreatedAtActionResult)await sut.Create(req);

        // Then
        result.StatusCode.Should().Be(201);
        result.Value.As<UserResponse>().FullName.Should().Be(req.FullName);
        result.RouteValues!["id"].Should().BeEquivalentTo(user.Id);
    }

    [Fact]
    public async Task Create_ShouldReturnBadRequest_WhenUserWasntCreated() {
        // Given
        userService.CreateAsync(Arg.Any<User>()).Returns(false);

        // When
        var result = (BadRequestResult)await sut.Create(new CreateUserRequest());

        // Then
        result.StatusCode.Should().Be(400);
    }

    [Fact]
    public async Task DeleteById_ShouldReturnOk_WhenUserWasDeleted() {
        // Given
        userService.DeleteByIdAsync(Arg.Any<Guid>()).Returns(true);

        // When
        var result = (OkResult)await sut.DeleteById(Guid.NewGuid());

        // Then
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task DeleteById_ShouldReturnNotFound_WhenUserDoesntExist() {
        // Given
        userService.DeleteByIdAsync(Arg.Any<Guid>()).Returns(false);

        // When
        var result = (NotFoundResult)await sut.DeleteById(Guid.NewGuid());

        // Then
        result.StatusCode.Should().Be(404);
    }
}
