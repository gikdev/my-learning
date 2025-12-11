using Api.Endpoints.Todos;

namespace Api.Endpoints;

public static class EndpointsExtensions {
    public static IEndpointRouteBuilder MapApiEndpoints(this IEndpointRouteBuilder app) {
        // Todos
        app.MapCreateTodo();
        app.MapDeleteTodo();
        app.MapGetTodoById();
        app.MapListTodos();
        app.MapUpdateTodo();

        // Categories

        return app;
    }
}
