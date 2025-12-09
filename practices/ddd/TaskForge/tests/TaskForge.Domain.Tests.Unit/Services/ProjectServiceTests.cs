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
    private readonly IProjectsRepository projectsRepository = Substitute.For<IProjectsRepository>();
    private readonly ProjectService sut;

    public ProjectServiceTests() {
        sut = new ProjectService(projectsRepository);
    }

    [Fact]
    public async Task CreateProjectAsync_ShouldReturnError_WhenTitleIsNotUnique() {
        // Arrange
        projectsRepository.ExistsWithTitleAsync(Arg.Any<NonEmptyTitle>()).Returns(true);

        // Act
        var result = await sut.CreateProjectAsync("Some invalid project title");

        // Assert
        result.IsError.Should().Be(true);
        result.FirstError.Should().Be(ProjectServiceErrors.DuplicateProjectTitle);
    }

    [Fact]
    public async Task CreateProjectAsync_ShouldCreateValidProject_WhenTitleIsUnique() {
        // Arrange
        var projectTitle = "Some valid project title";
        projectsRepository.ExistsWithTitleAsync(Arg.Any<NonEmptyTitle>()).Returns(false);

        // Act
        var result = await sut.CreateProjectAsync(projectTitle);

        // Assert
        result.IsError.Should().Be(false);
        result.Value.As<DomainProject>().Title.Value.Should().Be(projectTitle);
    }

    [Fact]
    public async Task RenameProjectAsync_ShouldReturnError_WhenProjectDoesntExist() {
        // Arrange
        var projectTitle = "Some valid project title";
        projectsRepository.GetByIdAsync(Arg.Any<Guid>()).ReturnsNull();

        // Act
        var result = await sut.RenameProjectAsync(Guid.NewGuid(), projectTitle);

        // Assert
        result.IsError.Should().Be(true);
        result.FirstError.Should().Be(ProjectServiceErrors.ProjectNotFound);
    }

    [Fact]
    public async Task RenameProjectAsync_ShouldReturnError_WhenProjectTitleIsNotUnique() {
        // Arrange
        var projectTitle = "Some valid project title";
        var titleResult = NonEmptyTitle.Create(projectTitle);
        titleResult.IsError.Throw().IfTrue();
        var newProject = new DomainProject(titleResult.Value);
        projectsRepository.GetByIdAsync(Arg.Any<Guid>()).Returns(newProject);
        projectsRepository.ExistsWithTitleAsync(Arg.Any<NonEmptyTitle>()).Returns(true);

        // Act
        var result = await sut.RenameProjectAsync(Guid.NewGuid(), projectTitle);

        // Assert
        result.IsError.Should().Be(true);
        result.FirstError.Should().Be(ProjectServiceErrors.DuplicateProjectTitle);
    }

    [Fact]
    public async Task RenameProjectAsync_ShouldRenameSuccessfully_WhenProjectTitleIsUnique() {
        // Arrange
        // Act
        // Assert
    }
}
