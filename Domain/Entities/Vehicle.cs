using Domain.Common;

namespace Domain.Entities;

public class Vehicle : EntityBase
{
    public string LicensePlate { get; private set; }
    public string Brand { get; private set; }
    public string Color { get; private set; }

    public ICollection<ParkingSession> Sessions { get; private set; } = [];
    
}