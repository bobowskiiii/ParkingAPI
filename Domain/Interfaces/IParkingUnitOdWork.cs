namespace Domain.Interfaces;

public interface IParkingUnitOdWork
{
    IVehicleRepository VehicleRepository { get; }
    IParkingGateRepository ParkingGateRepository { get; }
    IParkingSessionRepository ParkingSessionRepository { get; }
    IParkingTariffRepository ParkingTariffRepository { get; }
    ICameraCaptureRepository CameraCaptureRepository { get; }
    
    Task<int> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}