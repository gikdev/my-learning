using Domain.Todos;
using Throw;

namespace Domain.Categories;

public class Category {
    private readonly List<Guid> _todoIds = [];

    public Guid Id { get; private set; }
    public string Title { get; private set; }

    public Category(string title) {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty", nameof(title));

        Id = Guid.NewGuid();
        Title = title;
    }

    public void AddTodo(Todo todo) {
        _todoIds.Throw().IfContains(todo.Id);

        todo.ChangeCategory(Id);

        _todoIds.Add(todo.Id);
    }

    public bool HasTodo(Guid todoId)
        => _todoIds.Contains(todoId);

    public void RemoveTodo(Todo todo) {
        _todoIds.Throw().IfNotContains(todo.Id);

        todo.RemoveCategory();

        _todoIds.Remove(todo.Id);
    }
}
