using Api.Mappings;
using App.Todos.Commands.CreateTodo;
using Contracts.Todos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DomainTodoImportance = Domain.Todos.TodoImportance;

namespace Api.Endpoints.Todos;

public static class CreateTodoEndpoint {
    public const string Name = "CreateTodo";
    public const string Summary = "Create a new todo";
    public const string Endpoint = ApiEndpoints.Todos.Create;
    public const string Tag = ApiTags.Todos;

    public static IEndpointRouteBuilder MapCreateTodo(this IEndpointRouteBuilder app) {
        app
            .MapPost(Endpoint, HandleCreateTodo)
            .Produces<TodoResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary(Summary)
            .WithName(Name)
            .WithTags(Tag);

        return app;
    }

    private static async Task<IResult> HandleCreateTodo(
        [FromServices] ISender mediator,
        [FromBody] CreateTodoRequest request
    ) {
        var wasOk = DomainTodoImportance.TryFromName(
            request.Importance.ToString(),
            out var importance
        );

        if (!wasOk)
            return Results.ValidationProblem(
                new Dictionary<string, string[]> {
                    ["importance"] = ["Invalid importance value"]
                }
            );

        var command = new CreateTodoCommand(request.Title, importance);

        var createTodoResult = await mediator.Send(command);

        return createTodoResult.Match(
            todo => Results.CreatedAtRoute(
                nameof(GetTodoByIdEndpoint.Name),
                new { id = todo.Id },
                todo.MapToResponse()),
            ApiResults.Problem
        );

        // OLD:
        // return createTodoResult.Match(
        //     todo => CreatedAtAction(
        //         nameof(GetTodo),
        //         new { id = todo.Id },
        //         todo.MapToResponse()),
        //     Problem
        // );
    }
}
