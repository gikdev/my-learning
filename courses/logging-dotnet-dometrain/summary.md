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
