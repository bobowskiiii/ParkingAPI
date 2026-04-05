using Domain.Common;

namespace Domain.Entities;

public class ParkingSession : EntityBase
{
    public Guid VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }
    
    public Guid ParkingGateId { get; set; }
    public ParkingGate ParkingGate { get; set; }
    
    public Guid ParkingTariffId { get; set; }
    public ParkingTariff ParkingTariff { get; set; }
    
    public string GateName { get; set; }
    public DateTime EntryTime { get; set; }
    public DateTime? ExitTime { get; set; }
    public TimeSpan? Duration { get; set; }
    public decimal? Fee { get; set; }
    public bool IsActive { get; set; }

    
    public void Complete(ParkingTariff tariff)
    {
        if (this.IsActive)
            throw new InvalidOperationException("Session is already completed");

        ExitTime = DateTime.UtcNow;
        Fee = tariff.CalculateFee(ExitTime.Value - EntryTime);
        IsActive = false;
    }
}