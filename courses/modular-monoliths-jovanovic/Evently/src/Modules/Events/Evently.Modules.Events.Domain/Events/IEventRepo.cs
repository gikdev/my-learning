namespace Evently.Modules.Events.Domain.Events;

public interface IEventRepo {
    void Insert(Event @event);
}
