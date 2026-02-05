using FluentAssertions;
using TaskForge.Domain.Common.ValueObjects;
using TaskForge.Domain.LabelAggregate;
using Throw;

namespace TaskForge.Domain.Tests.Unit.LabelAggregate;

public class LabelTests {
    private readonly Label _sut = new(
        NonEmptyTitle.Create(TestConstants.Label.SampleTitle1).Value
    );

    [Fact]
    public void Rename_ShouldRenameSuccessfully() {
        // Arrange
        var newTitleResult = NonEmptyTitle.Create(TestConstants.Label.SampleTitle2);
        newTitleResult.IsError.Throw().IfTrue();

        // Act
        _sut.Rename(newTitleResult.Value);

        // Assert
        _sut.Title.Value.Should().Be(TestConstants.Label.SampleTitle2);
    }
}
