using Moduben.Api.Extensions;
using Moduben.Api.Middleware;
using Moduben.Common.Application;
using Moduben.Common.Infrastructure;
using Moduben.Common.Presentation.Endpoints;
using Moduben.Modules.Main.Infrastructure;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddOpenApi();

builder.Services.AddApplication([
    Moduben.Modules.Main.Application.AssemblyReference.Assembly,
]);

string databaseConnectionString = builder.Configuration.GetConnectionString("Database")!;
string redisConnectionString = builder.Configuration.GetConnectionString("Cache")!;

builder.Services.AddInfrastructure(
    [],
    databaseConnectionString,
    redisConnectionString
);

builder.Configuration.AddModuleConfiguration(["main"]);

builder.Services.AddHealthChecks()
    .AddNpgSql(databaseConnectionString)
    .AddRedis(redisConnectionString)
    .AddUrlGroup(new Uri(builder.Configuration.GetValue<string>("KeyCloak:HealthUrl")!), HttpMethod.Get, "keycloak");

builder.Services.AddMainModule(builder.Configuration);

WebApplication app = builder.Build();

app.MapOpenApi();

if (app.Environment.IsDevelopment()) {
    app.ApplyMigrations();
}

app.MapEndpoints();

app.MapHealthChecks("health", new HealthCheckOptions {
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

app.UseAuthentication();

app.UseAuthorization();

await app.RunAsync();
