using System.Data.Common;
using Evently.Modules.Events.Application.Abstractions.Data;
using Npgsql;

namespace Evently.Modules.Events.Infrastructure.Data;

internal sealed class DbConnFactory(NpgsqlDataSource npgsqlDataSource) : IDbConnFactory
{
    public async ValueTask<DbConnection> OpenConnectionAsync()
    {
        return await npgsqlDataSource.OpenConnectionAsync();
    }
}
