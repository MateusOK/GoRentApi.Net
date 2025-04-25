using GoRent.Domain.Repositories;
using GoRent.Infrastructure.Database;
using GoRent.Infrastructure.Ioc.DependencyInjection;
using GoRent.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructure();

builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("DatabaseSettings"));

builder.Services.AddSingleton<MongoDbContext>();
builder.Services.AddScoped<ICarRepository, CarRepository>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();