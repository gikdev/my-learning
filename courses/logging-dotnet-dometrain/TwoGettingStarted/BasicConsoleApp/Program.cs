using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

using var loggerFactory = LoggerFactory.Create(builder => {
    builder.ClearProviders();

    builder.AddJsonConsole(options => {
        options.IncludeScopes = false;
        options.TimestampFormat = "HH:mm:ss ";
        options.JsonWriterOptions = new() {
            Indented = true,
        };
    });
    // builder.SetMinimumLevel(LogLevel.Debug);
    // builder.AddConsole();

    builder.AddFilter((provider, category, logLevel) => {
        return provider!.Contains("Console")
            && category!.Contains("Microsoft.Extensions.Hosting.Internal.Host")
            && logLevel >= LogLevel.Debug;
    });

    builder
        .AddFilter("System", LogLevel.Debug)
        .AddFilter<ConsoleLoggerProvider>("Microsoft", LogLevel.Warning);
});

ILogger logger = loggerFactory.CreateLogger<Program>();

var age = 18;
var name = "Bahrami";

// WRONG! 👇🏻
// logger.LogInformation($"Hello World! {age}");

// CORRECT!
logger.LogInformation("Hello world! I'm {Age}", age);
logger.LogDebug("Hello world! I'm {Age}", age);

logger.LogInformation(5001, "Hello world! I'm {Age}", age);

logger.Log(LogLevel.Information, 0, "Hello world!");

try {
    throw new Exception("Something went wrong...");
} catch (Exception ex) {
    logger.LogError(ex, "Failure during birthday of {Name}", name);
}
