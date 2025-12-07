using System.Data;
using Npgsql;

namespace GymManagement.Infrastructure.Common.Persistence;

public interface IDbConnectionFactory {
    Task<IDbConnection> CreateConnectionAsync(CancellationToken token = default);
}

public class NpgsqlConnectionFactory(string connectionString) : IDbConnectionFactory {
    public async Task<IDbConnection> CreateConnectionAsync(CancellationToken token = default) {
        var conn = new NpgsqlConnection(connectionString);
        await conn.OpenAsync(token);
        return conn;
    }
}
