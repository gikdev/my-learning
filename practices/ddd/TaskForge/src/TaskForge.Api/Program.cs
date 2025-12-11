using TaskForge.Application;
using TaskForge.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApiStuff()
    .AddApplicationStuff();

builder
    .Build()
    .MapApiStuff()
    .Run();
