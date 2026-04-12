using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Memory;

public class InMemoryParkingGateRepository : MemoryGenericRepository<ParkingGate>, IParkingGateRepository
{
    public Task<ParkingGate?> GetByNameAsync(string name)
    {
        var result = _data.Values
            .FirstOrDefault(g => g.Name == name);
        
        return Task.FromResult(result);
    }
}