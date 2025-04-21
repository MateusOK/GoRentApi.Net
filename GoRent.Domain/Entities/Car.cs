namespace GoRent.Domain.Entities;

public class Car
{
    public Guid Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string Plate { get; set; }
    public decimal DailyRate { get; set; }
    public bool IsAvailable { get; set; }
}