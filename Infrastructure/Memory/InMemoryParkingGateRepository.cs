using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;

namespace Infrastructure.Memory;

public class InMemoryParkingGateRepository : MemoryGenericRepository<ParkingGate>, IParkingGateRepository
{
    public InMemoryParkingGateRepository()
    {
        var gate1 = new ParkingGate("Entry Gate", GateType.Entry, "Main Entrance");
        _data.Add(gate1.Id, gate1);

        var gate2 = new ParkingGate("Exit Gate", GateType.Exit, "Main Exit");
        _data.Add(gate2.Id, gate2);
    }

    public Task<ParkingGate?> GetByNameAsync(string name)
    {
        var result = _data.Values
            .FirstOrDefault(g => g.Name == name);
        
        return Task.FromResult(result);
    }
}