using Api.Mappings;
using App.Todos.Queries.ListTodos;
using Contracts.Todos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints.Todos;

public static class ListTodosEndpoint {
    public const string Name = "ListTodos";
    public const string Summary = "Get all todos (w/ filtering)";
    public const string Endpoint = ApiEndpoints.Todos.List;
    public const string Tag = ApiTags.Todos;

    public static IEndpointRouteBuilder MapListTodos(this IEndpointRouteBuilder app) {
        app
            .MapGet(Endpoint, HandleListTodos)
            .Produces<IEnumerable<TodoResponse>>(StatusCodes.Status200OK)
            .WithSummary(Summary)
            .WithName(Name)
            .WithTags(Tag);

        return app;
    }

    private static async Task<IResult> HandleListTodos(
        [FromServices] ISender mediator,
        [FromQuery(Name = "category_id")] Guid? categoryId,
        [FromQuery(Name = "is_completed")] bool? isCompleted,
        [FromQuery(Name = "importance")] TodoImportance? importance,
        [FromQuery(Name = "search_query")] string? searchQuery
    ) {
        var query = new ListTodosQuery {
            CategoryId = categoryId,
            Importance = importance?.ToSmartEnum(),
            IsCompleted = isCompleted,
            SearchQuery = searchQuery
        };

        var listTodosResult = await mediator.Send(query);

        return listTodosResult.Match(
            todos => Results.Ok(todos.Select(t => t.MapToResponse())),
            ApiResults.Problem
        );
    }
}
