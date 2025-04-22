using GoRent.Domain.Entities;

namespace GoRent.Domain.Repositories;

public interface ICarRepository
{
    Task<Car?> GetByIdAsync(Guid id);
    Task<IEnumerable<Car>> GetAllAsync();
    Task AddAsync(Car car);
    Task UpdateAsync(Car car);
    Task DeleteAsync(Car car);
}