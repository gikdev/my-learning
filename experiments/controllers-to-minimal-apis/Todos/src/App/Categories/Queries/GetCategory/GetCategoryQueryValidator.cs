using FluentValidation;

namespace App.Categories.Queries.GetCategory;

public class GetCategoryQueryValidator : AbstractValidator<GetCategoryQuery> {
    public GetCategoryQueryValidator() {
        RuleFor(x => x.CategoryId)
            .NotEmpty();
    }
}

