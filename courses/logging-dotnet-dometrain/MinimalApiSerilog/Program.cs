using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .WriteTo.Console(theme: AnsiConsoleTheme.Sixteen)
    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
    .CreateLogger();

Log.Logger = logger;

builder.Services.AddSingleton(logger);

var app = builder.Build();

app.MapGet("/", (Serilog.ILogger log) => {
    log.Information("Hello from the endpoint!");
    return "Hello World!";
});

app.Run();
