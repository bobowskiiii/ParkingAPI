using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Memory;

public class InMemoryVehicleRepository : MemoryGenericRepository<Vehicle>, IVehicleRepository
{
    public Task<Vehicle?> GetByLicensPlateAsync(string licensePlate)
    {
        var result = _data.Values
            .FirstOrDefault(v => v.LicensePlate
                .Equals(licensePlate, StringComparison.OrdinalIgnoreCase));
        
        return Task.FromResult(result);
    }
}   