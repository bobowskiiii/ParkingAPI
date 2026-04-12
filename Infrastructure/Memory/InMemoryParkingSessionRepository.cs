using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Memory;

public class InMemoryParkingSessionRepository : MemoryGenericRepository<ParkingSession>, IParkingSessionRepository
{
    public Task<ParkingSession?> FindByLicensePlateAsync(string licensePlate)
    {
        var result = _data.Values
            .FirstOrDefault(s => s.Vehicle.LicensePlate
                .Equals(licensePlate, StringComparison.OrdinalIgnoreCase));
        
        return Task.FromResult(result);
    }

    public Task<IEnumerable<ParkingSession>> FindAllActiveAsync()
    {
        var result = _data.Values
            .Where(s => s.IsActive);
        
        return Task.FromResult(result);
    }

    public Task<IEnumerable<ParkingSession?>> FindHistoryByLicensePlateAsync(string licensePlate)
    {
        var result = _data.Values
            .Where(s => s.Vehicle.LicensePlate
                .Equals(licensePlate, StringComparison.OrdinalIgnoreCase))
            .AsEnumerable();
        
        return Task.FromResult(result);
    }
}