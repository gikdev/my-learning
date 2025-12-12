using TaskForge.Application;
using TaskForge.Api.Extensions;
using TaskForge.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApiStuff()
    .AddApplicationStuff()
    .AddInfrastructureStuff();

builder
    .Build()
    .MapApiStuff()
    .Run();
