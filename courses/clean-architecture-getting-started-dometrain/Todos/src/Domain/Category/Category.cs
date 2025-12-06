namespace Domain.Category;

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
}
