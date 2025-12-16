using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

var logger = new LoggerConfiguration()
    .WriteTo.Console(theme: AnsiConsoleTheme.Sixteen)
    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
    .Destructure.ByTransforming<Payment>(x => new { x.PaymentId, x.UserId })
    .CreateLogger();

Payment payment = new() {
    OccuredAt = DateTime.Now,
    PaymentId = 1,
    UserId = Guid.NewGuid(),
};

logger.Information("Payment with {@Data}", payment);

logger.Information("Hello world!");
