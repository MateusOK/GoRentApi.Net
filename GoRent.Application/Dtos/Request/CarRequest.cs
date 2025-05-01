namespace GoRent.Application.Dtos.Request;

public record CarRequest()
{
    public string Brand { get; init; }
    public string Model { get; init; }
    public string Plate { get; init; }
    public int Year { get; init; }
    public decimal DailyRate { get; init; }
    public bool IsAvailable { get; init; }
};