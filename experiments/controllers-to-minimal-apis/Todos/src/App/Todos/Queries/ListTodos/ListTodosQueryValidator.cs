using Domain.Todos;
using FluentValidation;

namespace App.Todos.Queries.ListTodos;

public class ListTodosQueryValidator : AbstractValidator<ListTodosQuery> {
    public ListTodosQueryValidator() {
        RuleFor(x => x.CategoryId)
            .NotEmpty()
            .When(x => x.CategoryId.HasValue);

        RuleFor(x => x.Importance)
            .Must(i => i == null || TodoImportance.List.Contains(i))
            .WithMessage("Invalid importance value");

        RuleFor(x => x.SearchQuery)
            .MaximumLength(100)
            .When(x => !string.IsNullOrWhiteSpace(x.SearchQuery));
    }
}
