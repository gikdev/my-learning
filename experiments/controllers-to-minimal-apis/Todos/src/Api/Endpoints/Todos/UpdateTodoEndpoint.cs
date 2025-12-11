using Contracts.Todos;
using MediatR;
using Api.Mappings;
using Microsoft.AspNetCore.Mvc;
using App.Todos.Commands.UpdateTodo;

namespace Api.Endpoints.Todos;

public static class UpdateTodoEndpoint {
    public const string Name = "UpdateTodo";
    public const string Summary = "Update fields of a todo";
    public const string Endpoint = ApiEndpoints.Todos.Update;
    public const string Tag = ApiTags.Todos;

    public static IEndpointRouteBuilder MapUpdateTodo(this IEndpointRouteBuilder app) {
        app.MapPatch(Endpoint, HandleUpdateTodo)
           .Produces(StatusCodes.Status204NoContent)
           .WithSummary(Summary)
           .WithName(Name)
           .WithTags(Tag);

        return app;
    }

    private static async Task<IResult> HandleUpdateTodo(
        [FromServices] ISender mediator,
        [FromRoute] Guid id,
        [FromBody] UpdateTodoRequest request
    ) {
        var command = new UpdateTodoCommand(
            TodoId: id,
            NewTitle: request.NewTitle,
            Importance: request.Importance?.ToSmartEnum(),
            Completed: request.Completed
        );

        var result = await mediator.Send(command);

        if (result.IsError) return ApiResults.Problem(result.Errors);

        return Results.NoContent();
    }
}
