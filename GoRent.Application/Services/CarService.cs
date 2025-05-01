using GoRent.Application.Dtos.Request;
using GoRent.Application.Dtos.Response;
using GoRent.Application.Services.Interfaces;
using GoRent.Domain.Entities;
using GoRent.Domain.Repositories;

namespace GoRent.Application.Services;

public class CarService : ICarService
{

    private readonly ICarRepository _carRepository;

    public CarService(ICarRepository carRepository)
    {
        _carRepository = carRepository; 
    }
    
    public async Task<CarResponse> CreateAsync(CarRequest carRequest)
    {
        var car = new Car
        {
            Brand = carRequest.Brand,
            Model = carRequest.Model,
            Plate = carRequest.Plate,
            Year = carRequest.Year,
            DailyRate = carRequest.DailyRate,
            IsAvailable = carRequest.IsAvailable
        };
        await _carRepository.AddAsync(car);
        return CarResponse.FromEntity(car);
    }

    public async Task<List<CarResponse>> GetAllAsync()
    {
        var cars = await _carRepository.GetAllAsync();
        return cars.Select(car => CarResponse.FromEntity(car)).ToList();

    }

    public async Task<CarResponse?> GetByIdAsync(string id)
    {
        var car = await _carRepository.GetByIdAsync(Guid.Parse(id));
        return car is null ? null : CarResponse.FromEntity(car);
    }
}