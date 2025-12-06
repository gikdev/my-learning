using ErrorOr;

namespace Domain.Todo;

public class Todo {
    private readonly Guid? _categoryId;

    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public bool IsCompleted { get; private set; }
    public TodoImportance Importance { get; private set; }

    public Todo(string title, TodoImportance? importance = null) {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty", nameof(title));

        Id = Guid.NewGuid();
        Title = title;
        IsCompleted = false;
        Importance = importance ?? TodoImportance.Low;
    }

    public void ToggleCompleted() => IsCompleted = !IsCompleted;

    public ErrorOr<Success> ChangeImportance(TodoImportance importance) {
        if (IsCompleted) return TodoErrors.CannotChangeImportanceIfTodoIsCompleted;

        Importance = importance;

        return Result.Success;
    }

    public void Rename(string newTitle) {
        if (string.IsNullOrWhiteSpace(newTitle))
            throw new ArgumentException("newTitle cannot be empty", nameof(newTitle));

        Title = newTitle;
    }

   public void ChangeCategory() {}
}
