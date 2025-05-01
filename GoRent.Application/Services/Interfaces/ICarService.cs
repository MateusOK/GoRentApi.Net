using GoRent.Application.Dtos.Request;
using GoRent.Application.Dtos.Response;

namespace GoRent.Application.Services.Interfaces;

public interface ICarService
{
    Task<CarResponse> CreateAsync(CarRequest carRequest);
    Task<List<CarResponse>> GetAllAsync();
    Task<CarResponse?> GetByIdAsync(string id);
}