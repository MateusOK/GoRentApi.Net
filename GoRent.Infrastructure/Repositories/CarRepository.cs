using GoRent.Domain.Entities;
using GoRent.Domain.Repositories;

namespace GoRent.Infrastructure.Repositories;

public class CarRepository : ICarRepository
{
    public Task<Car?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Car>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Car car)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Car car)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Car car)
    {
        throw new NotImplementedException();
    }
}