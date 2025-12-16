# Summary

- Logging is recording what happened. For debugging, or whatever...

- Logs have:
    - levels
    - categories
    - provider (destination basically)

- Structured logging:

    ```csharp
    // WRONG! 👇🏻
    // logger.LogInformation($"Hello World! {age}");

    // CORRECT!
    logger.LogInformation("Hello world! I'm {Age}", age);
    ```

- Set minimum log level:

    ```csharp
    builder
        .SetMinimumLevel(LogLevel.Debug)
        .AddJsonConsole();
    ```

- Log's event id, that is a way we can label the operation!

    ```csharp
    logger.LogInformation(LogEvents.UserBirthday, "Hello world! I'm {Age}", age);

    public static class LogEvents {
        public const int UserBirthday = 5001;
    }
    ```

- More advanced options:

    ```cs
    builder.ClearProviders();

    builder.AddJsonConsole(options => {
        options.IncludeScopes = false;
        options.TimestampFormat = "HH:mm:ss ";
        options.JsonWriterOptions = new() {
            Indented = true,
        };
    });
    ```

- AppSettings.json

    ```jsonc
    {
        "Logging": {
            "LogLevel": {
                "Default": "Information",
                "Microsoft.AspNetCore": "Warning"
            },
            "Console": {
                "LogLevel": {
                    "Default": "Information",
                    "Microsoft.AspNetCore": "Information"
                },
                "FormatterName": "json", // simple
                "FormatterOptions": {
                    "SingleLine": true,
                    "IncludeScopes": true,
                    "TimestampFormat": "HH:mm:ss ",
                    "UseUtcTimestamp": true,
                    "JsonWriterOptions": {
                        "Indented": true
                    }
                }
            }
        }
    }
    ```

- Exceptions:

    ```cs
    catch (Exception ex) {
        logger.LogError(ex, "Failure during birthday of {Name}", name);
    }
    ```

- Filters:

    ```cs
        builder.AddFilter((provider, category, logLevel) => {
            return provider!.Contains("Console")
                && category!.Contains("Microsoft.Extensions.Hosting.Internal.Host")
                && logLevel >= LogLevel.Debug;
        });

        builder
            .AddFilter("System", LogLevel.Debug)
            .AddFilter<ConsoleLoggerProvider>("Microsoft", LogLevel.Warning);
    ```

- Log scope: the same context / situation for a couple of logs...

    ```cs
    .AddJsonConsole(o => o.IncludeScopes = true);
    // ...
    var paymentId = 32;
    var total = 24.54m;

    using (logger.BeginScope("{PaymentId}", paymentId)) {
        try {
            logger.IsEnabled(LogLevel.Information);
            logger.LogInformation("New payment for {Total:C}", total);
            // processing.
        } catch {

        } finally {
            logger.LogInformation("Payment processing completed.");
        }
    }
    ```

- Serilog in ASP.NET Core

    ```cs
    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .CreateLogger();

    builder.Host.UseSerilog();
    ```

- Structure logging in Serilog:

    ```cs
    Payment payment = new() {
        OccuredAt = DateTime.Now,
        PaymentId = 1,
        UserId = Guid.NewGuid(),
    };

    logger.Information("Payment with {@Data}", payment);
    ```

- Filter stuff:

    ```cs
    var logger = new LoggerConfiguration()
        .WriteTo.Console(theme: AnsiConsoleTheme.Sixteen)
        .Destructure.ByTransforming<Payment>(x => new { x.PaymentId, x.UserId }) // !!!
        .CreateLogger();
    ```

- Hide some data:

    - package: `Destructurama.Attributed`

    ```cs
    .Destructure.UsingAttributes()
    // ...
    [LogMasked(ShowFirst = 3, PreserveLength = true)]
    // [NotLogged]
    public string Email { get; set;}
    // "itsme@me.com" -> "its*********"
    ```
