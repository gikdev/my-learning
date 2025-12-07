namespace GymManagement.Application.Common.Interfaces;

/// <summary>
/// Represents a unit of work that encapsulates a set of operations
/// to be committed as a single transaction.
/// </summary>
public interface IUnitOfWork {
    /// <summary>
    /// Commits all pending changes to the underlying data store.
    /// </summary>
    /// <returns>
    /// A task representing the asynchronous commit operation.
    /// </returns>
    Task CommitChangesAsync();
}
