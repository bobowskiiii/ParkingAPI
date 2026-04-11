using Domain.Common;

namespace Domain.Entities;

public class Vehicle : EntityBase
{
    public string LicensePlate { get; private set; }
    public string Brand { get; private set; }
    public string Color { get; private set; }

    public ICollection<ParkingSession> Sessions { get; private set; } = [];
    
    private Vehicle() { }


    public Vehicle(string licensePlate, string brand, string color)
    {
        Id = Guid.NewGuid();
        LicensePlate = licensePlate;
        Brand = brand;
        Color = color;
    }

    public void UpdateColor(string color)
    {
        if (string.IsNullOrWhiteSpace(color))
            throw new ArgumentException("Color cannot be empty", nameof(color));
        
        Color = color;
    }
}