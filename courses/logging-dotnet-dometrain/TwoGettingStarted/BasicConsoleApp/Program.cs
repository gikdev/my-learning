using Microsoft.Extensions.Logging;

using var loggerFactory = LoggerFactory.Create(builder => {
    builder
        .SetMinimumLevel(LogLevel.Debug)
        .AddJsonConsole();
    // builder.AddConsole();
});

ILogger logger = loggerFactory.CreateLogger<Program>();

var age = 18;

// WRONG! 👇🏻
// logger.LogInformation($"Hello World! {age}");

// CORRECT!
logger.LogInformation("Hello world! I'm {Age}", age);
logger.LogDebug("Hello world! I'm {Age}", age);

logger.LogInformation(5001, "Hello world! I'm {Age}", age);

logger.Log(LogLevel.Information, 0, "Hello world!");
