using FluentAssertions;
using TaskForge.Domain.Common.ValueObjects;

namespace TaskForge.Domain.Tests.Unit.Common.ValueObjects;

public class NonEmptyTitleTests {
    [Fact]
    public async Task Create_ShouldGiveError_WhenInputIsEmpty() {
        // Act
        var result = NonEmptyTitle.Create("");

        // Assert
        result.IsError.Should().Be(true);
        result.FirstError.Should().Be(NonEmptyTitleErrors.CannotBeEmpty);
    }

    [Fact]
    public async Task Create_ShouldCreateSuccessfully_WhenInputIsNotEmpty() {
        var input = "Hello world!";

        // Act
        var result = NonEmptyTitle.Create(input);

        // Assert
        result.IsError.Should().Be(false);
        result.Value.Value.Should().Be(input);
    }
}
