using Ims.Modules.Ticketing.Domain.Events;

namespace Ims.Modules.Ticketing.Domain.Tickets;

public interface ITicketRepository {
    Task<IEnumerable<Ticket>> GetForEventAsync(Event @event, CancellationToken cancellationToken = default);

    void InsertRange(IEnumerable<Ticket> tickets);
}
