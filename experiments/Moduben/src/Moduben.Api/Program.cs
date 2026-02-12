using Moduben.Api.Extensions;
using Moduben.Api.Middleware;
using Moduben.Common.Application;
using Moduben.Common.Infrastructure;
using Moduben.Common.Presentation.Endpoints;
using Moduben.Modules.Main.Infrastructure;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Serilog;
using Npgsql;
using Scalar.AspNetCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
ConfigurationManager config  = builder.Configuration;
string dbConnStr = new NpgsqlConnectionStringBuilder {
    Host     = config.GetValue<string?>("DB_HOST")     ?? throw new Exception("DB_HOST not set"),
    Port     = config.GetValue<int?>("DB_PORT")        ?? throw new Exception("DB_PORT not set"),
    Database = config.GetValue<string?>("DB_NAME")     ?? throw new Exception("DB_NAME not set"),
    Username = config.GetValue<string?>("DB_USER")     ?? throw new Exception("DB_USER not set"),
    Password = config.GetValue<string?>("DB_PASSWORD") ?? throw new Exception("DB_PASSWORD not set")
}.ConnectionString;

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddOpenApi();

builder.Services.AddApplication([
    Moduben.Modules.Main.Application.AssemblyReference.Assembly,
]);

builder.Services.AddInfrastructure(
    [MainModule.ConfigureConsumers],
    dbConnStr
);

builder.Configuration.AddModuleConfiguration(["main"]);

builder.Services.AddHealthChecks()
    .AddNpgSql(dbConnStr);

builder.Services.AddMainModule(builder.Configuration);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.ApplyMigrations();
}

app.MapOpenApi();

app.MapEndpoints();
app.MapScalarApiReference();

app.MapHealthChecks("health", new HealthCheckOptions {
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

app.UseAuthentication();

app.UseAuthorization();

await app.RunAsync();
