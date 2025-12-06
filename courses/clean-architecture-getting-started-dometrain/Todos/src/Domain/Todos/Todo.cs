using ErrorOr;
using Throw;

namespace Domain.Todos;

public class Todo {
    private Guid? _categoryId;

    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public bool IsCompleted { get; private set; }
    public TodoImportance Importance { get; private set; }

    public Todo(string title, TodoImportance? importance = null) {
        title.Throw().IfNullOrWhiteSpace(s => s);

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
        newTitle.Throw().IfNullOrWhiteSpace(s => s);

        Title = newTitle;
    }

    public void ChangeCategory(Guid categoryId)
        => _categoryId = categoryId;

    public void RemoveCategory()
        => _categoryId = null;
}
