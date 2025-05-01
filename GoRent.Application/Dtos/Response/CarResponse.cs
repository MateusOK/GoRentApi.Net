using GoRent.Domain.Entities;

namespace GoRent.Application.Dtos.Response;

public record CarResponse(string Id, string Brand, string Model, string Plate, int Year, decimal DailyRate, bool IsAvailable)
{
    public static CarResponse FromEntity(Car car)
    {
        return new CarResponse(car.Id.ToString(), car.Brand, car.Model, car.Plate, car.Year, car.DailyRate, car.IsAvailable);
    }
};