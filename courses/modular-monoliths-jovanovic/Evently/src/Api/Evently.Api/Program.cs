using Evently.Api.Extensions;
using Evently.Common.Application;
using Evently.Common.Infrastructure;
using Evently.Modules.Events.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
ConfigurationManager config = builder.Configuration;

builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.CustomSchemaIds(t => t.FullName?.Replace("+", "."));
});

builder.Services.AddApplication([
    Evently.Modules.Events.Application.AssemblyReference.Assembly,
]);
builder.Services.AddInfrastructure(config.GetConnectionString("Database")!);
builder.Configuration.AddModuleConfiguration(["events"]);
builder.Services.AddEventsModule(config);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyMigrations();
}

EventsModule.MapEndpoints(app);

app.Run();
