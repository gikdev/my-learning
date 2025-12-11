using ErrorOr;

namespace Domain.Todos;

public static class TodoErrors {
    public static readonly Error CannotChangeImportanceIfTodoIsCompleted = Error.Validation(
        "Todo.CannotChangeImportanceIfTaskIsCompleted",
        "The importance of a completed todo can NOT be changed."
    );
}
