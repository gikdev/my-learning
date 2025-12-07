using Ardalis.SmartEnum;

namespace Domain.Todos;

public class TodoImportance : SmartEnum<TodoImportance> {
    public static readonly TodoImportance Low = new(nameof(Low), 0);
    public static readonly TodoImportance Medium = new(nameof(Medium), 1);
    public static readonly TodoImportance High = new(nameof(High), 2);

    private TodoImportance(string name, int value) : base(name, value) {
    }
}
