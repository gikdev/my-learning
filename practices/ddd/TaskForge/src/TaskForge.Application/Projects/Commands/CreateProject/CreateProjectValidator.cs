using FluentValidation;
using TaskForge.Domain.ProjectAggregate;

namespace TaskForge.Application.Projects.Commands.CreateProject;

public class CreateProjectValidator : AbstractValidator<CreateProjectCommand> {
    public CreateProjectValidator() {
        RuleFor(x => x.Title)
            .MinimumLength(1)
            .WithMessage("Title shouldn't be empty.");

        RuleFor(x => x.Status)
            .Must(BeValidOrNull)
            .WithMessage("Status must be null or a valid ProjectStatus.");
    }

    private bool BeValidOrNull(ProjectStatus? status) {
        if (status is null) return true;

        return ProjectStatus.List.Contains(status);
    }
}
