# Dapper 2

```cs
using System.Data;
using Npgsql;

namespace App.Db;

public interface IDbConnectionFactory {
  Task<IDbConnection> CreateConnectionAsync(CancellationToken token = default);
}

public class NpgsqlConnectionFactory(string connStr) : IDbConnectionFactory {
  public async Task<IDbConnection> CreateConnectionAsync(CancellationToken token = default) {
    var conn = new NpgsqlConnection(connStr);
    await conn.OpenAsync(token);
    return conn;
  }
}
```

```cs
public class MovieRepo(IDbConnectionFactory dbConnectionFactory) : IMovieRepo {
  public async Task<IEnumerable<Movie>> GetAllAsync(GetAllMoviesOptions options, CancellationToken token = default) {
    using var conn = await dbConnectionFactory.CreateConnectionAsync(token);

    var getAllMoviesCmd = new CommandDefinition(" SELECT 1; ", new {}, cancellationToken: token);

    var result = await conn.QueryAsync(getAllMoviesCmd);

    var movies = result.Select(i => new Movie {
      // ...
    });

    return movies;
  }
}
```

```xml
  <PackageReference Include="Dapper" />
  <PackageReference Include="Microsoft.Extensions.DependencyInjection.Abstractions" />
  <PackageReference Include="NpgSql" />
```

```sh
dotnet add package Dapper;
dotnet add package NpgSql;
dotnet add package Microsoft.Extensions.DependencyInjection.Abstractions;
```
