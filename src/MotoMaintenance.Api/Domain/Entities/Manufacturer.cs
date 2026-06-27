namespace MotoMaintenance.Api.Domain.Entities;

public sealed class Motorcycle
{
    public int Id { get; set; }
    public required string Make { get; set; }
    public required string Model { get; set; }
    public int Year { get; set; }
    public required string Vin { get; set; }
}