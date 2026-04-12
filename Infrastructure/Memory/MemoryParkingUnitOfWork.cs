using Domain.Interfaces;

namespace Infrastructure.Memory;

public class MemoryParkingUnitOfWork(
    IVehicleRepository vehicles, 
    IParkingSessionRepository parkingSessions,
    IParkingGateRepository gates,
    IParkingTariffRepository tariffs,
    ICameraCaptureRepository captures
): IParkingUnitOfWork
{
    public IVehicleRepository VehicleRepository { get; } = vehicles;
    public IParkingGateRepository ParkingGateRepository { get; } = gates;
    public IParkingSessionRepository ParkingSessionRepository { get; } = parkingSessions;
    public IParkingTariffRepository ParkingTariffRepository { get; } = tariffs;
    public ICameraCaptureRepository CameraCaptureRepository { get; } = captures;
    
    public Task<int> SaveChangesAsync() => Task.FromResult(0);
    public Task BeginTransactionAsync() => Task.CompletedTask;
    public Task CommitTransactionAsync() => Task.CompletedTask;
    public Task RollbackTransactionAsync() => Task.CompletedTask;
}