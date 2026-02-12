using Moduben.Api.Extensions;
using Moduben.Api.Middleware;
using Moduben.Common.Application;
using Moduben.Common.Infrastructure;
using Moduben.Common.Presentation.Endpoints;
using Moduben.Infrastructure;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) => {
    loggerConfig.ReadFrom.Configuration(context.Configuration);
});
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddOpenApi();

builder.Services.AddApplication([
    Moduben.Application.AssemblyReference.Assembly,
]);

string dbConnStr = builder.Configuration.GetConnectionString("Database")!;
builder.Services.AddInfrastructure(dbConnStr);

builder.Configuration.AddModuleConfiguration(["events", "users", "ticketing", "attendance"]);

builder.Services.AddHealthChecks()
    .AddNpgSql(dbConnStr);

builder.Services.AddMainModule(builder.Configuration);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.ApplyMigrations();
}

app.MapOpenApi();
app.MapEndpoints();
app.MapHealthChecks("health", new HealthCheckOptions {
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.UseSerilogRequestLogging();
app.UseExceptionHandler();

await app.RunAsync();
