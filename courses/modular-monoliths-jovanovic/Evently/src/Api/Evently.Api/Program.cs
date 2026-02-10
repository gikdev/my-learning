
using Evently.Api.Extensions;
using Evently.Modules.Events.Api;

namespace Evently.Api;

#pragma warning disable CA1515 // Consider making public types internal
public static class Program
#pragma warning restore CA1515
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        ConfigurationManager config = builder.Configuration;

        builder.Services.AddAuthorization();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddEventsModule(config);

        WebApplication app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            app.ApplyMigrations();
        }

        EventsModule.MapEndpoints(app);

        app.Run();
    }
}
