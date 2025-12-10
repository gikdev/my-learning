using FluentAssertions;
using TaskForge.Domain.Common.ValueObjects;
using TaskForge.Domain.ProjectAggregate;
using Throw;

namespace TaskForge.Domain.Tests.Unit.ProjectAggregate;

public class ProjectTests {
    private readonly Project _sut;

    public ProjectTests() {
        var errorOrTitle = NonEmptyTitle.Create(TestConstants.Project.SampleTitle1);
        errorOrTitle.IsError.Throw().IfTrue();

        _sut = new Project(
            errorOrTitle.Value
        );
    }

    // AddTask ---------------------------------------------------------

    [Fact]
    public void AddTask_ShouldReturnError_WhenProjectIsCompleted() {
        // Arrange
        _sut.Complete();
        _sut.IsCompleted.Throw().IfFalse();

        // Act
        var addedTaskResult = _sut.AddTask(TestConstants.Task.SampleTitle1);

        // Assert
        addedTaskResult.IsError.Should().Be(true);
        addedTaskResult.Errors.Should().HaveCount(1);
        addedTaskResult.FirstError.Should().Be(ProjectErrors.CannotAddTaskToCompletedProject);
    }

    [Fact]
    public void AddTask_ShouldReturnError_WhenTitleIsEmpty() {
        // Arrange
        // Act
        var addedTaskResult = _sut.AddTask(TestConstants.Task.EmptyTitle);

        // Assert
        addedTaskResult.IsError.Should().Be(true);
        addedTaskResult.Errors.Should().HaveCount(1);
    }

    [Fact]
    public void AddTask_ShouldReturnError_WhenTitleIsDuplicate() {
        // Arrange
        var errorOrTask1 = _sut.AddTask(TestConstants.Task.SampleTitle1);
        errorOrTask1.IsError.Throw().IfTrue();

        // Act
        var addedTaskResult = _sut.AddTask(TestConstants.Task.SampleTitle1);

        // Assert
        addedTaskResult.IsError.Should().Be(true);
        addedTaskResult.Errors.Should().HaveCount(1);
        addedTaskResult.FirstError.Should().Be(ProjectErrors.DuplicateTaskTitle);
        _sut.TaskCount.Should().Be(1);
    }

    [Fact]
    public void AddTask_ShouldAddTask_WhenValid() {
        // Arrange
        // Act
        var addedTaskResult = _sut.AddTask(TestConstants.Task.SampleTitle1);

        // Assert
        addedTaskResult.IsError.Should().Be(false);
        _sut.TaskCount.Should().Be(1);
    }


    // RemoveTask ------------------------------------------------------

    [Fact]
    public void RemoveTask_ShouldReturnError_WhenTaskNotFound() {
        // Arrange
        // Act
        var removedTaskResult = _sut.RemoveTask(Guid.NewGuid());

        // Assert
        removedTaskResult.IsError.Should().Be(true);
        removedTaskResult.Errors.Should().HaveCount(1);
        removedTaskResult.FirstError.Should().Be(ProjectErrors.TaskNotFound);
    }

    [Fact]
    public void RemoveTask_ShouldRemoveTask_WhenFound() {
        // Arrange
        var errorOrTask = _sut.AddTask(TestConstants.Task.SampleTitle1);
        errorOrTask.IsError.Throw().IfTrue();
        var task = errorOrTask.Value;

        // Act
        var removedTaskResult = _sut.RemoveTask(task.Id);

        // Assert
        removedTaskResult.IsError.Should().Be(false);
        _sut.TaskCount.Should().Be(0);
    }


    // RenameTask ------------------------------------------------------

    [Fact]
    public void RenameTask_ShouldReturnError_WhenTitleIsEmpty() {
        // Arrange
        var errorOrTask = _sut.AddTask(TestConstants.Task.SampleTitle1);
        errorOrTask.IsError.Throw().IfTrue();
        var task = errorOrTask.Value;

        // Act
        var renamedTaskResult = _sut.RenameTask(task.Id, TestConstants.Task.EmptyTitle);

        // Assert
        renamedTaskResult.IsError.Should().Be(true);
        renamedTaskResult.Errors.Should().HaveCount(1);
    }

    [Fact]
    public void RenameTask_ShouldReturnError_WhenTaskNotFound() {
        // Arrange
        // Act
        var renamedTaskResult = _sut.RenameTask(Guid.NewGuid(), TestConstants.Task.SampleTitle1);

        // Assert
        renamedTaskResult.IsError.Should().Be(true);
        renamedTaskResult.Errors.Should().HaveCount(1);
        renamedTaskResult.FirstError.Should().Be(ProjectErrors.TaskNotFound);
    }

    [Fact]
    public void RenameTask_ShouldReturnError_WhenTitleIsDuplicate() {
        // Arrange
        var errorOrTask1 = _sut.AddTask(TestConstants.Task.SampleTitle1);
        errorOrTask1.IsError.Throw().IfTrue();
        var task1 = errorOrTask1.Value;

        var errorOrTask2 = _sut.AddTask(TestConstants.Task.SampleTitle2);
        errorOrTask2.IsError.Throw().IfTrue();
        var task2 = errorOrTask2.Value;

        // Act
        var renamedTaskResult = _sut.RenameTask(task1.Id, task2.Title.Value);

        // Assert
        renamedTaskResult.IsError.Should().Be(true);
        renamedTaskResult.Errors.Should().HaveCount(1);
        renamedTaskResult.FirstError.Should().Be(ProjectErrors.DuplicateTaskTitle);
    }

    [Fact]
    public void RenameTask_ShouldRenameTask_WhenValid() {
        // Arrange
        var errorOrTask = _sut.AddTask(TestConstants.Task.SampleTitle1);
        errorOrTask.IsError.Throw().IfTrue();
        var task = errorOrTask.Value;

        // Act
        var renamedTaskResult = _sut.RenameTask(task.Id, TestConstants.Task.SampleTitle2);

        // Assert
        renamedTaskResult.IsError.Should().Be(false);
        renamedTaskResult.Value.Title.Value.Should().Be(TestConstants.Task.SampleTitle2);
        renamedTaskResult.Value.Should().BeSameAs(task);
        _sut.TaskCount.Should().Be(1);
    }


    // RemoveLabelFromAllTasks ----------------------------------------

    [Fact]
    public void RemoveLabelFromAllTasks_ShouldRemoveLabelFromEveryTask() {
        // Arrange
        var labelId1 = Guid.NewGuid();
        var labelId2 = Guid.NewGuid();

        var addedTask1Result = _sut.AddTask(TestConstants.Task.SampleTitle1);
        addedTask1Result.IsError.Throw().IfTrue();
        var task1 = addedTask1Result.Value;

        var addedTask2Result = _sut.AddTask(TestConstants.Task.SampleTitle2);
        addedTask2Result.IsError.Throw().IfTrue();
        var task2 = addedTask2Result.Value;

        task1.AddLabel(labelId1);
        task1.AddLabel(labelId2);

        task2.AddLabel(labelId1);
        task2.AddLabel(labelId2);

        // Act
        _sut.RemoveLabelFromAllTasks(labelId1);

        // Assert
        task1.LabelIds.Count.Should().Be(1);
        task1.LabelIds.Should().Contain(labelId2);
        task1.LabelIds.Should().NotContain(labelId1);

        task2.LabelIds.Count.Should().Be(1);
        task2.LabelIds.Should().Contain(labelId2);
        task2.LabelIds.Should().NotContain(labelId1);
    }
}
