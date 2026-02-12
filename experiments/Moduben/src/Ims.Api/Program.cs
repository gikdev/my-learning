// ReSharper disable RedundantNameQualifier

using System.Reflection;
using HealthChecks.UI.Client;
using Ims.Api.Extensions;
using Ims.Api.Middleware;
using Ims.Api.OpenTelemetry;
using Ims.Common.Application;
using Ims.Common.Infrastructure;
using Ims.Common.Infrastructure.Configuration;
using Ims.Common.Infrastructure.EventBus;
using Ims.Common.Presentation.Endpoints;
using Ims.Modules.Attendance.Infrastructure;
using Ims.Modules.Events.Infrastructure;
using Ims.Modules.Users.Application;
using Ims.Modules.Users.Infrastructure;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using RabbitMQ.Client;
using Scalar.AspNetCore;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddOpenApi();

Assembly[] moduleApplicationAssemblies = [
    Ims.Modules.Users.Application.AssemblyReference.Assembly,
    Ims.Modules.Events.Application.AssemblyReference.Assembly,
    Ims.Modules.Attendance.Application.AssemblyReference.Assembly
];

builder.Services.AddApplication(moduleApplicationAssemblies);

string databaseConnectionString = builder.Configuration.GetConnectionStringOrThrow("Database");
string redisConnectionString    = builder.Configuration.GetConnectionStringOrThrow("Cache");
var    rabbitMqSettings         = new RabbitMqSettings(builder.Configuration.GetConnectionStringOrThrow("Queue"));

builder.Services.AddInfrastructure(
    DiagnosticsConfig.ServiceName,
    [
        EventsModule.ConfigureConsumers(redisConnectionString),
        AttendanceModule.ConfigureConsumers,
        UsersModule.ConfigureConsumers
    ],
    rabbitMqSettings,
    databaseConnectionString,
    redisConnectionString);

Uri keyCloakHealthUrl = builder.Configuration.GetKeyCloakHealthUrl();

builder.Services.AddHealthChecks()
    .AddNpgSql(databaseConnectionString)
    .AddRedis(redisConnectionString)
    .AddRabbitMQ(sp => {
        var factory = new ConnectionFactory {
            Uri = new Uri(rabbitMqSettings.Host)
        };

        return factory.CreateConnectionAsync();
    })
    .AddKeyCloak(keyCloakHealthUrl);

builder.Configuration.AddModuleConfiguration(["users", "events", "attendance"]);

builder.Services.AddEventsModule(builder.Configuration);

builder.Services.AddUsersModule(builder.Configuration);

builder.Services.AddAttendanceModule(builder.Configuration);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.ApplyMigrations();
}

app.MapOpenApi();

app.MapHealthChecks("health", new HealthCheckOptions {
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseLogContextTraceLogging();

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

app.UseAuthentication();

app.UseAuthorization();

app.MapEndpoints();

app.MapScalarApiReference();

await app.RunAsync();

#pragma warning disable CA1515
public partial class Program;
#pragma warning restore CA1515
