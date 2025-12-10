using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using TaskForge.Domain.Common.Interfaces;
using TaskForge.Domain.Common.ValueObjects;
using TaskForge.Domain.LabelAggregate;
using TaskForge.Domain.ProjectAggregate;
using TaskForge.Domain.Services;
using Throw;
using Task = System.Threading.Tasks.Task;

namespace TaskForge.Domain.Tests.Unit.Services;

public class LabelServiceTests {
    private readonly ILabelsRepository _labelsRepository = Substitute.For<ILabelsRepository>();
    private readonly LabelService _sut;

    public LabelServiceTests() {
        _sut = new LabelService(_labelsRepository);
    }

    // CreateLabelAsync ------------------------------------------------

    [Fact]
    public async Task CreateLabelAsync_ShouldReturnError_WhenTitleIsNotUnique() {
        // Arrange
        _labelsRepository.ExistsWithTitleAsync(Arg.Any<NonEmptyTitle>()).Returns(true);

        // Act
        var result = await _sut.CreateLabelAsync(TestConstants.Label.SampleTitle1);

        // Assert
        result.IsError.Should().BeTrue();
        result.FirstError.Should().Be(LabelServiceErrors.DuplicateLabelTitle);
    }

    [Fact]
    public async Task CreateLabelAsync_ShouldCreateLabel_WhenTitleIsUnique() {
        // Arrange
        _labelsRepository.ExistsWithTitleAsync(Arg.Any<NonEmptyTitle>()).Returns(false);

        // Act
        var result = await _sut.CreateLabelAsync(TestConstants.Label.SampleTitle1);

        // Assert
        result.IsError.Should().BeFalse();
        result.Value.As<Label>().Title.Value.Should().Be(TestConstants.Label.SampleTitle1);
    }


    // RenameLabelAsync ------------------------------------------------

    [Fact]
    public async Task RenameLabelAsync_ShouldReturnError_WhenLabelNotFound() {
        // Arrange
        _labelsRepository.GetByIdAsync(Arg.Any<Guid>()).ReturnsNull();

        // Act
        var result = await _sut.RenameLabelAsync(Guid.NewGuid(), TestConstants.Label.SampleTitle1);

        // Assert
        result.IsError.Should().BeTrue();
        result.FirstError.Should().Be(LabelServiceErrors.LabelNotFound);
    }

    [Fact]
    public async Task RenameLabelAsync_ShouldReturnError_WhenTitleIsNotUnique() {
        // Arrange
        var title = NonEmptyTitle.Create(TestConstants.Label.SampleTitle1);
        title.IsError.Throw().IfTrue();

        var existingLabel = new Label(title.Value);

        _labelsRepository.GetByIdAsync(Arg.Any<Guid>()).Returns(existingLabel);
        _labelsRepository.ExistsWithTitleAsync(Arg.Any<NonEmptyTitle>(), Arg.Any<Guid>()).Returns(true);

        // Act
        var result = await _sut.RenameLabelAsync(Guid.NewGuid(), TestConstants.Label.SampleTitle1);

        // Assert
        result.IsError.Should().BeTrue();
        result.FirstError.Should().Be(LabelServiceErrors.DuplicateLabelTitle);
    }

    [Fact]
    public async Task RenameLabelAsync_ShouldRenameSuccessfully_WhenTitleIsUnique() {
        // Arrange
        var original = NonEmptyTitle.Create(TestConstants.Label.SampleTitle1);
        original.IsError.Throw().IfTrue();

        var existingLabel = new Label(original.Value);

        _labelsRepository.GetByIdAsync(Arg.Any<Guid>()).Returns(existingLabel);
        _labelsRepository.ExistsWithTitleAsync(Arg.Any<NonEmptyTitle>(), Arg.Any<Guid>()).Returns(false);

        // Act
        var result = await _sut.RenameLabelAsync(Guid.NewGuid(), TestConstants.Label.SampleTitle2);

        // Assert
        result.IsError.Should().BeFalse();
        result.Value.Title.Value.Should().Be(TestConstants.Label.SampleTitle2);
    }

    // RemoveLabelFromAllProjects ------------------------------------------------

    [Fact]
    public void RemoveLabelFromAllProjects_ShouldSuccessfullyRemoveFromAllProjects() {
        // Arrange
        var labelId = Guid.NewGuid();

        var title1Result = NonEmptyTitle.Create("T1");
        title1Result.IsError.Throw().IfTrue();
        var title1 = title1Result.Value;

        var title2Result = NonEmptyTitle.Create("T2");
        title2Result.IsError.Throw().IfTrue();
        var title2 = title2Result.Value;

        var project1 = new Project(title1);
        var project2 = new Project(title2);

        project1.AddTask(title1.Value).Value.AddLabel(labelId);
        project2.AddTask(title2.Value).Value.AddLabel(labelId);

        var projects = new List<Project> { project1, project2 };

        project1.Tasks.First().LabelIds.Throw().IfNotContains(labelId);
        project2.Tasks.First().LabelIds.Throw().IfNotContains(labelId);

        // Act
        _sut.RemoveLabelFromAllProjects(projects, labelId);

        // Assert
        project1.Tasks.First().LabelIds.Should().NotContain(labelId);
        project2.Tasks.First().LabelIds.Should().NotContain(labelId);
    }
}
