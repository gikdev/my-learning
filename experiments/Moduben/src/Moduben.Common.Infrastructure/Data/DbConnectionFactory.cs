using System.Data.Common;
using Moduben.Common.Application.Data;
using Npgsql;

namespace Moduben.Common.Infrastructure.Data;

internal sealed class DbConnectionFactory(NpgsqlDataSource dataSource) : IDbConnectionFactory {
    public async ValueTask<DbConnection> OpenConnectionAsync() {
        return await dataSource.OpenConnectionAsync();
    }
}
