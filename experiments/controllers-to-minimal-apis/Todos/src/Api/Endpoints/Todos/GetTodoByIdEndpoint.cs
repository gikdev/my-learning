using Api.Mappings;
using App.Todos.Queries.GetTodo;
using Contracts.Todos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints.Todos;

public static class GetTodoByIdEndpoint {
    public const string Name = "GetTodoById";
    public const string Summary = "Get a todo by ID";
    public const string Endpoint = ApiEndpoints.Todos.GetById;
    public const string Tag = ApiTags.Todos;

    public static IEndpointRouteBuilder MapGetTodoById(this IEndpointRouteBuilder app) {
        app
            .MapGet(Endpoint, HandleGetTodoById)
            .Produces<TodoResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary(Summary)
            .WithName(Name)
            .WithTags(Tag);

        return app;
    }

    private static async Task<IResult> HandleGetTodoById(
        [FromServices] ISender mediator,
        [FromRoute] Guid id
    ) {
        var query = new GetTodoQuery(id);

        var getTodoResult = await mediator.Send(query);

        return getTodoResult.Match(
            todo => Results.Ok(todo.MapToResponse()),
            ApiResults.Problem
        );
    }
}
