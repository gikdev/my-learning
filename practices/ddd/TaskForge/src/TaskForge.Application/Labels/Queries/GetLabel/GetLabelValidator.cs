using FluentValidation;

namespace TaskForge.Application.Labels.Queries.GetLabel;

public class GetLabelValidator : AbstractValidator<GetLabelQuery> {
    public GetLabelValidator() {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}
