using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using TaskForge.Domain.Common.Interfaces;
using TaskForge.Domain.Common.ValueObjects;
using TaskForge.Domain.Services;
using Throw;
using DomainProject = TaskForge.Domain.ProjectAggregate.Project;

namespace TaskForge.Domain.Tests.Unit.Services;

public class ProjectServiceTests {
    private readonly IProjectsRepository _projectsRepository = Substitute.For<IProjectsRepository>();
    private readonly ProjectService _sut;

    public ProjectServiceTests() {
        _sut = new ProjectService(_projectsRepository);
    }

    [Fact]
    public async Task CreateProjectAsync_ShouldReturnError_WhenTitleIsNotUnique() {
        // Arrange
        _projectsRepository.ExistsWithTitleAsync(Arg.Any<NonEmptyTitle>()).Returns(true);

        // Act
        var result = await _sut.CreateProjectAsync(TestConstants.Project.SampleTitle1);

        // Assert
        result.IsError.Should().Be(true);
        result.FirstError.Should().Be(ProjectServiceErrors.DuplicateProjectTitle);
    }

    [Fact]
    public async Task CreateProjectAsync_ShouldCreateValidProject_WhenTitleIsUnique() {
        // Arrange
        _projectsRepository.ExistsWithTitleAsync(Arg.Any<NonEmptyTitle>()).Returns(false);

        // Act
        var result = await _sut.CreateProjectAsync(TestConstants.Project.SampleTitle1);

        // Assert
        result.IsError.Should().Be(false);
        result.Value.As<DomainProject>().Title.Value.Should().Be(TestConstants.Project.SampleTitle1);
    }

    [Fact]
    public async Task RenameProjectAsync_ShouldReturnError_WhenProjectDoesntExist() {
        // Arrange
        _projectsRepository.GetByIdAsync(Arg.Any<Guid>()).ReturnsNull();

        // Act
        var result = await _sut.RenameProjectAsync(Guid.NewGuid(), TestConstants.Project.SampleTitle1);

        // Assert
        result.IsError.Should().Be(true);
        result.FirstError.Should().Be(ProjectServiceErrors.ProjectNotFound);
    }

    [Fact]
    public async Task RenameProjectAsync_ShouldReturnError_WhenProjectTitleIsNotUnique() {
        // Arrange
        var titleResult = NonEmptyTitle.Create(TestConstants.Project.SampleTitle1);
        titleResult.IsError.Throw().IfTrue();
        var newProject = new DomainProject(titleResult.Value);
        _projectsRepository.GetByIdAsync(Arg.Any<Guid>()).Returns(newProject);
        _projectsRepository.ExistsWithTitleAsync(Arg.Any<NonEmptyTitle>(), Arg.Any<Guid>()).Returns(true);

        // Act
        var result = await _sut.RenameProjectAsync(Guid.NewGuid(), TestConstants.Project.SampleTitle1);

        // Assert
        result.IsError.Should().Be(true);
        result.FirstError.Should().Be(ProjectServiceErrors.DuplicateProjectTitle);
    }

    [Fact]
    public async Task RenameProjectAsync_ShouldRenameSuccessfully_WhenProjectTitleIsUnique() {
        // Arrange
        var titleResult = NonEmptyTitle.Create(TestConstants.Project.SampleTitle1);
        titleResult.IsError.Throw().IfTrue();
        var existingProject = new DomainProject(titleResult.Value);
        _projectsRepository.GetByIdAsync(Arg.Any<Guid>()).Returns(existingProject);
        _projectsRepository.ExistsWithTitleAsync(Arg.Any<NonEmptyTitle>()).Returns(false);

        // Act
        var result = await _sut.RenameProjectAsync(Guid.NewGuid(), TestConstants.Project.SampleTitle1);

        // Assert
        result.IsError.Should().Be(false);
        result.Value.As<DomainProject>().Title.Value.Should().Be(TestConstants.Project.SampleTitle1);
    }
}
