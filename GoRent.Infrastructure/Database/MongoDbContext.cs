using GoRent.Domain.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GoRent.Infrastructure.Database;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IOptions<DatabaseSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        _database = client.GetDatabase(settings.Value.DatabaseName);
    }

    public IMongoCollection<Car> Cars => _database.GetCollection<Car>("cars");
}