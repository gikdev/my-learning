using Api.Mappings;
using App.Todos.Commands.ChangeTodoImportance;
using App.Todos.Commands.CreateTodo;
using App.Todos.Commands.DeleteTodo;
using App.Todos.Commands.RenameTodo;
using App.Todos.Commands.ToggleTodoCompleted;
using App.Todos.Queries.GetTodo;
using Contracts.Todos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DomainTodoImportance = Domain.Todos.TodoImportance;

namespace Api.Controllers;

public class TodosController(ISender mediator) : ApiController {
    [EndpointSummary("Create a new todo")]
    [HttpPost(ApiEndpoints.Todos.Create)]
    [ProducesResponseType(typeof(TodoResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateTodo([FromBody] CreateTodoRequest request) {
        var wasOk = DomainTodoImportance.TryFromName(
            request.Importance.ToString(),
            out var importance
        );

        if (!wasOk)
            return Problem(
                statusCode: StatusCodes.Status400BadRequest,
                detail: "Invalid importance"
            );

        var command = new CreateTodoCommand(request.Title, importance);

        var createTodoResult = await mediator.Send(command);

        return createTodoResult.Match(
            todo => CreatedAtAction(
                nameof(GetTodo),
                new { id = todo.Id },
                todo.MapToResponse()),
            Problem
        );
    }

    [EndpointSummary("Delete a todo by ID")]
    [HttpDelete(ApiEndpoints.Todos.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteTodo([FromRoute] Guid id) {
        var command = new DeleteTodoCommand(id);

        var deleteTodoResult = await mediator.Send(command);

        return deleteTodoResult.Match(
            _ => NoContent(),
            Problem
        );
    }

    [EndpointSummary("Get all todos with optional filtering")]
    [HttpGet(ApiEndpoints.Todos.List)]
    [ProducesResponseType(typeof(IEnumerable<TodoResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListTodos(
        [FromQuery] ListTodosRequest request
    ) {
        var query = request.MapToQuery();

        var listTodosResult = await mediator.Send(query);

        return listTodosResult.Match(
            todos => Ok(todos.Select(t => t.MapToResponse())),
            Problem
        );
    }

    [EndpointSummary("Get a todo by ID")]
    [HttpGet(ApiEndpoints.Todos.GetById)]
    [ProducesResponseType(typeof(TodoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetTodo([FromRoute] Guid id) {
        var query = new GetTodoQuery(id);

        var getTodoResult = await mediator.Send(query);

        return getTodoResult.Match(
            todo => Ok(todo.MapToResponse()),
            Problem
        );
    }

    [EndpointSummary("Rename a todo")]
    [HttpPatch(ApiEndpoints.Todos.Rename)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> RenameTodo([FromBody] RenameTodoRequest request, [FromRoute] Guid id) {
        var command = new RenameTodoCommand(id, request.NewTitle);

        var result = await mediator.Send(command);

        return result.Match(
            _ => NoContent(),
            Problem
        );
    }

    [EndpointSummary("Change the importance level of a todo")]
    [HttpPatch(ApiEndpoints.Todos.ChangeImportance)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> ChangeTodoImportance(
        [FromBody] ChangeTodoImportanceRequest request,
        [FromRoute] Guid id
    ) {
        var command = new ChangeTodoImportanceCommand(id, request.Importance.ToSmartEnum());

        var result = await mediator.Send(command);

        return result.Match(
            _ => NoContent(),
            Problem
        );
    }

    [EndpointSummary("Toggle the completed status of a todo")]
    [HttpPatch(ApiEndpoints.Todos.ToggleCompleted)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> ToggleTodoCompleted(
        [FromRoute] Guid id
    ) {
        var command = new ToggleTodoCompletedCommand(id);

        var result = await mediator.Send(command);

        return result.Match(
            _ => NoContent(),
            Problem
        );
    }
}
