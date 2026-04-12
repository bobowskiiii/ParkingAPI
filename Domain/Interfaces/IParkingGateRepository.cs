using Domain.Common;
using Domain.Entities;

namespace Domain.Interfaces;

public interface IParkingGateRepository : IGenericRepositoryAsync<ParkingGate>
{
    Task<ParkingGate?> GetByNameAsync(string name);
}