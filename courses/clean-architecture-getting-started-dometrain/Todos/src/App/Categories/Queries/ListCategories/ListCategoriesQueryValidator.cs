using FluentValidation;

namespace App.Categories.Queries.ListCategories;

public class ListCategoriesQueryValidator : AbstractValidator<ListCategoriesQuery> {
    public ListCategoriesQueryValidator() {
        // No parameters to validate
    }
}

