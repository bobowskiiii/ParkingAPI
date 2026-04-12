using Domain.Interfaces;

namespace Infrastructure.Memory;

public class MemoryParkingUnitOfWork(
    IVehicleRepository vehicles, 
    IParkingSessionRepository parkingSessions,
    IParkingGateRepository gates,
    IParkingTariffRepository tariffs,
    ICameraCaptureRepository captures
) : IParkingUnitOdWork
{
    public IVehicleRepository VehicleRepository { get; }
    public IParkingGateRepository ParkingGateRepository { get; }
    public IParkingSessionRepository ParkingSessionRepository { get; }
    public IParkingTariffRepository ParkingTariffRepository { get; }
    public ICameraCaptureRepository CameraCaptureRepository { get; }
    
    public Task<int> SaveChangesAsync() => Task.FromResult(0);

    public Task BeginTransactionAsync() => Task.CompletedTask;

    public Task CommitTransactionAsync() => Task.CompletedTask;

    public Task RollbackTransactionAsync() => Task.CompletedTask;
}