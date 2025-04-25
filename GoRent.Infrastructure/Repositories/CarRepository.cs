using GoRent.Domain.Entities;
using GoRent.Domain.Repositories;
using GoRent.Infrastructure.Database;
using MongoDB.Driver;

namespace GoRent.Infrastructure.Repositories;

public class CarRepository(MongoDbContext context) : ICarRepository
{
    
    private readonly IMongoCollection<Car> _cars = context.Cars;

    public async Task<Car?> GetByIdAsync(Guid id)
    {
        return await _cars.Find(c => c.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<Car>> GetAllAsync()
    {
        return await _cars.Find(_ => true).ToListAsync();
    }

    public async Task AddAsync(Car car)
    {
        await _cars.InsertOneAsync(car);
    }

    public async Task UpdateAsync(Car car)
    {
        var filter = Builders<Car>.Filter.Eq(c => c.Id, car.Id);
        await _cars.ReplaceOneAsync(filter, car);
    }

    public async Task DeleteAsync(Car car)
    {
        var filter = Builders<Car>.Filter.Eq(c => c.Id, car.Id);
        await _cars.DeleteOneAsync(filter);
    }
}