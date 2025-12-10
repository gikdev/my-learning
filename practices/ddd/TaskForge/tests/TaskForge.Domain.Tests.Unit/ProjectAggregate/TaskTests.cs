using FluentAssertions;
using TaskForge.Domain.Common.ValueObjects;
using TaskForge.Domain.ProjectAggregate;
using Throw;
using DomainTask = TaskForge.Domain.ProjectAggregate.Task;
using TaskStatus = TaskForge.Domain.ProjectAggregate.TaskStatus;

namespace TaskForge.Domain.Tests.Unit.ProjectAggregate;

public class TaskTests {
    private readonly DomainTask _sut = new(
        NonEmptyTitle.Create(TestConstants.Task.SampleTitle1).Value
    );

    [Fact]
    public void ToggleStatus_ShouldSwitchFromPendingToCompleted() {
        // Arrange
        // Act
        _sut.ToggleStatus();

        // Assert
        _sut.Status.Should().Be(TaskStatus.Completed);
    }

    [Fact]
    public void ToggleStatus_ShouldSwitchFromCompletedToPending() {
        // Arrange
        _sut.ToggleStatus();
        _sut.Status.Throw().IfEquals(TaskStatus.Pending);

        // Act
        _sut.ToggleStatus();

        // Assert
        _sut.Status.Should().Be(TaskStatus.Pending);
    }

    [Fact]
    public void ChangeDescription_ShouldUpdateDescription() {
        // Arrange
        const string newDescription = "I'm an example description for a task.";

        // Act
        _sut.ChangeDescription(newDescription);

        // Assert
        _sut.Description.Should().Be(newDescription);
    }

    [Fact]
    public void ChangePriority_ShouldUpdatePriority() {
        // Arrange
        var isNull = _sut.Priority == null;
        isNull.Throw().IfFalse();
        var newPriority = TaskPriority.Hard;

        // Act
        _sut.ChangePriority(newPriority);

        // Assert
        _sut.Priority.Should().Be(newPriority);
    }

    [Fact]
    public void Rename_ShouldUpdateTitle() {
        // Arrange
        var errorOrNonEmptyTitle = NonEmptyTitle.Create(TestConstants.Task.SampleTitle1);
        errorOrNonEmptyTitle.IsError.Throw().IfTrue();
        var newTitle = errorOrNonEmptyTitle.Value;

        // Act
        _sut.Rename(newTitle);

        // Assert
        _sut.Title.Value.Should().Be(newTitle.Value);
    }

    [Fact]
    public void AddLabel_ShouldAddLabel_WhenNotAlreadyAdded() {
        // Arrange
        var labelId1 = Guid.NewGuid();
        var labelId2 = Guid.NewGuid();

        _sut.AddLabel(labelId1);

        // Act
        _sut.AddLabel(labelId2);

        // Assert
        _sut.LabelIds.Count.Should().Be(2);
    }

    [Fact]
    public void AddLabel_ShouldNotAddDuplicateLabel() {
        // Arrange
        var labelId1 = Guid.NewGuid();

        _sut.AddLabel(labelId1);

        // Act
        _sut.AddLabel(labelId1);

        // Assert
        _sut.LabelIds.Count.Should().Be(1);
    }

    [Fact]
    public void RemoveLabel_ShouldRemoveExistingLabel() {
        // Arrange
        var labelId1 = Guid.NewGuid();

        _sut.AddLabel(labelId1);

        // Act
        _sut.RemoveLabel(labelId1);

        // Assert
        _sut.LabelIds.Count.Should().Be(0);
    }

    [Fact]
    public void RemoveLabel_ShouldDoNothing_WhenLabelDoesNotExist() {
        // Arrange
        var labelId1 = Guid.NewGuid();
        var labelId2 = Guid.NewGuid();

        _sut.AddLabel(labelId1);

        // Act
        _sut.RemoveLabel(labelId2);

        // Assert
        _sut.LabelIds.Count.Should().Be(1);
    }
}
