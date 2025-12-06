using Domain.Todos;
using Throw;

namespace Domain.Categories;

public class Category {
    public Category(string title) {
        title.Throw().IfNullOrWhiteSpace(s => s);

        Id = Guid.NewGuid();
        Title = title;
    }

    public List<Guid> TodoIds { get; } = [];

    public Guid Id { get; }
    public string Title { get; private set; }

    public void Rename(string newTitle) {
        newTitle.Throw().IfNullOrWhiteSpace(s => s);

        Title = newTitle;
    }

    public void AddTodo(Todo todo) {
        TodoIds.Throw().IfContains(todo.Id);

        todo.ChangeCategory(Id);

        TodoIds.Add(todo.Id);
    }

    public bool HasTodo(Guid todoId) {
        return TodoIds.Contains(todoId);
    }

    public void RemoveTodo(Todo todo) {
        TodoIds.Throw().IfNotContains(todo.Id);

        todo.RemoveCategory();

        TodoIds.Remove(todo.Id);
    }
}
