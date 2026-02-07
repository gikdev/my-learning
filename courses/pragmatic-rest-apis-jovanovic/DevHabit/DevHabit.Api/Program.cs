using DevHabit.Api.Database;
using DevHabit.Api.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(o =>
{
    o.ReturnHttpNotAcceptable = true;
}).AddXmlSerializerFormatters();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbCtx>(o =>
{
    var connStr = builder.Configuration.GetConnectionString("Database");
    o.UseNpgsql(connStr, o =>
    {
        o.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Application);
    }).UseSnakeCaseNamingConvention();
});
builder.Services.AddOpenTelemetry()
    .ConfigureResource(res => res
        .AddService(builder.Environment.ApplicationName)
    )
    .WithTracing(tracing => tracing
        .AddHttpClientInstrumentation()
        .AddAspNetCoreInstrumentation()
        .AddNpgsql()
    )
    .WithMetrics(metrics => metrics
        .AddHttpClientInstrumentation()
        .AddAspNetCoreInstrumentation()
        .AddRuntimeInstrumentation()
    )
    .UseOtlpExporter();

builder.Logging.AddOpenTelemetry(options => {
    options.IncludeScopes = true;
    options.IncludeFormattedMessage = true;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    await app.ApplyMigrationsAsync();
}

app.UseHttpsRedirection();

app.MapControllers();

await app.RunAsync();
