using Domain.Common;

namespace Domain.Entities;

public class ParkingSession : EntityBase
{
    public Guid VehicleId { get; private set; }
    public Vehicle Vehicle { get; private set; }
    
    public Guid ParkingGateId { get; private set; }
    public ParkingGate ParkingGate { get; private set; }
    
    public Guid ParkingTariffId { get; private set; }
    public ParkingTariff ParkingTariff { get; private set; }
    
    public string GateName { get; private set; }
    public DateTime EntryTime { get; private set; }
    public DateTime? ExitTime { get; private set; }
    public TimeSpan? Duration { get; private set; }
    public decimal? Fee { get; private set; }
    public bool IsActive { get; private set; }

    private ParkingSession() { }
    public ParkingSession(Vehicle vehicle, ParkingGate parkingGate, ParkingTariff parkingTariff)
    {
        Vehicle = vehicle;
        ParkingGate = parkingGate;
        ParkingTariff = parkingTariff;
        EntryTime = DateTime.UtcNow;
        IsActive = true;
    }
    
    public void Complete(ParkingTariff tariff)
    {
        if (this.IsActive)
            throw new InvalidOperationException("Session is already completed");

        ExitTime = DateTime.UtcNow;
        Fee = tariff.CalculateFee(ExitTime.Value - EntryTime);
        IsActive = false;
    }
}