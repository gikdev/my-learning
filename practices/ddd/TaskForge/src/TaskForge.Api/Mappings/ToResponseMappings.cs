using System.Diagnostics.Contracts;
using TaskForge.Contracts.Labels;
using TaskForge.Contracts.Projects;
using TaskForge.Domain.LabelAggregate;
using TaskForge.Domain.ProjectAggregate;
using ContractProjectStatus = TaskForge.Contracts.Projects.ProjectStatus;

namespace TaskForge.Api.Mappings;

public static class ToResponseMappings {
    public static LabelResponse MapToResponse(this Label label) => new() {
        Id = label.Id,
        Title = label.Title.Value,
    };

    public static ProjectResponse MapToResponse(this Project project) => new() {
        Id = project.Id,
        Status = (ContractProjectStatus)project.Status.Value,
        Title = project.Title.Value,
    };
}
