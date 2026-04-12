using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Memory;

public class InMemoryParkingTariffRepository : MemoryGenericRepository<ParkingTariff>, IParkingTariffRepository
{
    public Task<ParkingTariff?> GetActiveAsync()
    {
        var result = _data.Values
            .FirstOrDefault(t => t.IsActive);
        
        return Task.FromResult(result);
    }

    public Task<IEnumerable<ParkingTariff>> GetAllActiveAsync()
    {
        var result = _data.Values
            .Where(t => t.IsActive)
            .AsEnumerable();
        
        return Task.FromResult(result);
    }
}