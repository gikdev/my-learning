using Api;
using Api.Endpoints;
using App;
using Infra;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApi()
    .AddApp()
    .AddInfra();

var app = builder.Build();

app.UseExceptionHandler();
app.MapOpenApi();
app.MapScalarApiReference();
app.UseHttpsRedirection();
app.UseAuthorization();
// app.MapControllers();
app.MapApiEndpoints();

app.Run();
