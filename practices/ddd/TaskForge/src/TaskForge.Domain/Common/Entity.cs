namespace TaskForge.Domain.Common;

public class Entity {
    protected Entity() {}

    protected Entity(Guid id) {
        Id = id;
    }

    public Guid Id { get; protected set; }

    public override bool Equals(object? obj) {
        if (obj is null || obj.GetType() != GetType()) return false;

        return ((Entity)obj).Id == Id;
    }

    public override int GetHashCode() {
        return Id.GetHashCode();
    }
}
