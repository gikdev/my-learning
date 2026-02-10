using System.Data.Common;

namespace Evently.Modules.Events.Application.Abstractions.Data;

public interface IDbConnFactory
{
    ValueTask<DbConnection> OpenConnectionAsync();
}
