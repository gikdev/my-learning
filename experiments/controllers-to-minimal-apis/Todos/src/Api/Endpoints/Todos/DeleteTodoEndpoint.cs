using App.Todos.Commands.DeleteTodo;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints.Todos;

public static class DeleteTodoEndpoint {
    public const string Name = "DeleteTodo";
    public const string Summary = "Delete a todo by ID";
    public const string Endpoint = ApiEndpoints.Todos.Delete;
    public const string Tag = ApiTags.Todos;

    public static IEndpointRouteBuilder MapDeleteTodo(this IEndpointRouteBuilder app) {
        app
            .MapDelete(Endpoint, HandleDeleteTodo)
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary(Summary)
            .WithName(Name)
            .WithTags(Tag);

        return app;
    }

    private static async Task<IResult> HandleDeleteTodo(
        [FromServices] ISender mediator,
        [FromRoute] Guid id
    ) {
        var command = new DeleteTodoCommand(id);

        var deleteTodoResult = await mediator.Send(command);

        return deleteTodoResult.Match(
            _ => Results.NoContent(),
            ApiResults.Problem
        );
    }
}
