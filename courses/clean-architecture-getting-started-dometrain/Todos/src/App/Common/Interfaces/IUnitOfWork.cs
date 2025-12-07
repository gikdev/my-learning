namespace App.Common.Interfaces;

public interface IUnitOfWork {
    Task CommitChangesAsync();
}
