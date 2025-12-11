var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://localhost:5024");

var app = builder.Build();

var todos = new List<Todo>();
var todosGroup = app.MapGroup("/todos");

todosGroup.MapGet("/", () => todos);

todosGroup.MapPost("/", (Todo todo) => {
    todo.Id = Guid.NewGuid();
    todos.Add(todo);
    return Results.Ok(todo);
});

todosGroup.MapGet("/{id}", (Guid id) =>
    todos.FirstOrDefault(t => t.Id == id) is { } found
        ? Results.Ok(found)
        : Results.NotFound()
);

todosGroup.MapDelete("/{id}", (Guid id) => {
    var todo = todos.FirstOrDefault(t => t.Id == id);
    if (todo is null) return Results.NotFound();
    todos.Remove(todo);
    return Results.NoContent();
});

app.Run();

class Todo {
    public Guid Id { get; set; }
    public string Title { get; set; } = "";
}
