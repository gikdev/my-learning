using Contracts.Todos;
using DomainTodoImportance = Domain.Todos.TodoImportance;

namespace Api.Mappings;

public static class Misc {
    public static TodoImportance ToNativeEnum(this DomainTodoImportance importance)
        => importance.Name switch {
            nameof(DomainTodoImportance.Low) => TodoImportance.Low,
            nameof(DomainTodoImportance.Medium) => TodoImportance.Medium,
            nameof(DomainTodoImportance.High) => TodoImportance.High,
            _ => throw new InvalidOperationException(),
        };

    public static DomainTodoImportance ToSmartEnum(this TodoImportance importance)
        => importance switch {
            TodoImportance.Low => DomainTodoImportance.Low,
            TodoImportance.Medium => DomainTodoImportance.Medium,
            TodoImportance.High => DomainTodoImportance.High,
            _ => throw new InvalidOperationException(),
        };
}
