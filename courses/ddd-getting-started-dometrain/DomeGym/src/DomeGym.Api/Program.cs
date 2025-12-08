using DomeGym.Application;
using DomeGym.Infrastructure;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddProblemDetails();
builder.Services.AddHttpContextAccessor();

builder.Services
    .AddApplication()
    .AddInfrastructure();

var app = builder.Build();

app.UseExceptionHandler();
app.MapOpenApi();
app.MapScalarApiReference(o => {
    o.Layout = ScalarLayout.Classic;
});
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
