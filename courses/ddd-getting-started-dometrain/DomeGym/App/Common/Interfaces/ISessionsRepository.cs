using Domain.SessionAggregate;

namespace App.Common.Interfaces;

public interface ISessionsRepository {
    Task AddSessionAsync(Session session);
    Task UpdateSessionAsync(Session session);
}
