using Api.Mappings;
using App.Categories.Commands.AddTodoToCategory;
using App.Categories.Commands.CreateCategory;
using App.Categories.Commands.DeleteCategory;
using App.Categories.Commands.RemoveTodoFromCategory;
using App.Categories.Commands.RenameCategory;
using App.Categories.Queries.GetCategory;
using App.Categories.Queries.ListCategories;
using Contracts.Categories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class CategoriesController(ISender mediator) : ApiController {
    [EndpointSummary("Create a new category")]
    [HttpPost(ApiEndpoints.Categories.Create)]
    [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request) {
        var command = new CreateCategoryCommand(request.Title);

        var result = await mediator.Send(command);

        return result.Match(
            category => CreatedAtAction(
                nameof(GetCategory),
                new { id = category.Id },
                category.MapToResponse()
            ),
            Problem
        );
    }

    [EndpointSummary("Delete a category by ID")]
    [HttpDelete(ApiEndpoints.Categories.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteCategory([FromRoute] Guid id) {
        var command = new DeleteCategoryCommand(id);

        var deleteCategoryResult = await mediator.Send(command);

        return deleteCategoryResult.Match(
            _ => NoContent(),
            Problem
        );
    }

    [EndpointSummary("Get all categories")]
    [HttpGet(ApiEndpoints.Categories.List)]
    [ProducesResponseType(typeof(IEnumerable<CategoryResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListCategories() {
        var query = new ListCategoriesQuery();

        var listCategoriesResult = await mediator.Send(query);

        return listCategoriesResult.Match(
            categories => Ok(categories.Select(c => c.MapToResponse())),
            Problem
        );
    }

    [EndpointSummary("Get a category by ID")]
    [HttpGet(ApiEndpoints.Categories.GetById)]
    [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCategory([FromRoute] Guid id) {
        var query = new GetCategoryQuery(id);

        var getCategoryResult = await mediator.Send(query);

        return getCategoryResult.Match(
            category => Ok(category.MapToResponse()),
            Problem
        );
    }

    [EndpointSummary("Rename a category")]
    [HttpPatch(ApiEndpoints.Categories.Rename)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> RenameCategory([FromRoute] Guid id, [FromBody] RenameCategoryRequest request) {
        var command = new RenameCategoryCommand(id, request.NewTitle);

        var renameCategoryResult = await mediator.Send(command);

        return renameCategoryResult.Match(
            _ => NoContent(),
            Problem
        );
    }

    [EndpointSummary("Add a todo to a category")]
    [HttpPost(ApiEndpoints.Categories.AddTodo)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> AddTodo([FromRoute] Guid categoryId, [FromRoute] Guid todoId) {
        var command = new AddTodoToCategoryCommand(categoryId, todoId);

        var addTodoResult = await mediator.Send(command);

        return addTodoResult.Match(
            _ => NoContent(),
            Problem
        );
    }

    [EndpointSummary("Remove a todo from a category")]
    [HttpDelete(ApiEndpoints.Categories.RemoveTodo)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> RemoveTodo([FromRoute] Guid categoryId, [FromRoute] Guid todoId) {
        var command = new RemoveTodoFromCategoryCommand(categoryId, todoId);

        var removeTodoResult = await mediator.Send(command);

        return removeTodoResult.Match(
            _ => NoContent(),
            Problem
        );
    }
}
