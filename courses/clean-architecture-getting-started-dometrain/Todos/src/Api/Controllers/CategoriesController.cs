using App.Categories.Commands.AddTodoToCategory;
using App.Categories.Commands.CreateCategory;
using App.Categories.Commands.DeleteCategory;
using App.Categories.Commands.RemoveTodoFromCategory;
using App.Categories.Commands.RenameCategory;
using App.Categories.Queries.GetCategory;
using App.Categories.Queries.ListCategories;
using Contracts.Categories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class CategoriesController(ISender mediator) : ApiController {
    [EndpointSummary("Create a new category")]
    [HttpPost(ApiEndpoints.Categories.Create)]
    public async Task<IActionResult> CreateCategory(CreateCategoryRequest request) {
        var command = new CreateCategoryCommand(request.Title);

        var createCategoryResult = await mediator.Send(command);

        return createCategoryResult.Match(
            category => CreatedAtAction(
                nameof(GetCategory),
                new { id = category.Id },
                new CategoryResponse {
                    Id = category.Id,
                    Title = category.Title
                }),
            Problem);
    }

    [EndpointSummary("Delete a category by ID")]
    [HttpDelete(ApiEndpoints.Categories.Delete)]
    public async Task<IActionResult> DeleteCategory(Guid id) {
        var command = new DeleteCategoryCommand(id);

        var deleteCategoryResult = await mediator.Send(command);

        return deleteCategoryResult.Match(
            _ => NoContent(),
            Problem);
    }

    [EndpointSummary("Get all categories")]
    [HttpGet(ApiEndpoints.Categories.List)]
    public async Task<IActionResult> ListCategories() {
        var query = new ListCategoriesQuery();

        var listCategoriesResult = await mediator.Send(query);

        return listCategoriesResult.Match(
            categories => Ok(categories.Select(category => new CategoryResponse {
                Id = category.Id,
                Title = category.Title
            })),
            Problem);
    }

    [EndpointSummary("Get a category by ID")]
    [HttpGet(ApiEndpoints.Categories.GetById)]
    public async Task<IActionResult> GetCategory(Guid id) {
        var query = new GetCategoryQuery(id);

        var getCategoryResult = await mediator.Send(query);

        return getCategoryResult.Match(
            category => Ok(new CategoryResponse {
                Id = category.Id,
                Title = category.Title
            }),
            Problem);
    }

    [EndpointSummary("Rename a category")]
    [HttpPatch(ApiEndpoints.Categories.Rename)]
    public async Task<IActionResult> RenameCategory(Guid id, RenameCategoryRequest request) {
        var command = new RenameCategoryCommand(id, request.NewTitle);

        var renameCategoryResult = await mediator.Send(command);

        return renameCategoryResult.Match(
            _ => NoContent(),
            Problem);
    }

    [EndpointSummary("Add a todo to a category")]
    [HttpPost(ApiEndpoints.Categories.AddTodo)]
    public async Task<IActionResult> AddTodo(Guid categoryId, Guid todoId) {
        var command = new AddTodoToCategoryCommand(categoryId, todoId);

        var addTodoResult = await mediator.Send(command);

        return addTodoResult.Match(
            _ => NoContent(),
            Problem);
    }

    [EndpointSummary("Remove a todo from a category")]
    [HttpDelete(ApiEndpoints.Categories.RemoveTodo)]
    public async Task<IActionResult> RemoveTodo(Guid categoryId, Guid todoId) {
        var command = new RemoveTodoFromCategoryCommand(categoryId, todoId);

        var removeTodoResult = await mediator.Send(command);

        return removeTodoResult.Match(
            _ => NoContent(),
            Problem);
    }
}
