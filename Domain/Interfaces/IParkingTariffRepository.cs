using Domain.Common;
using Domain.Entities;

namespace Domain.Interfaces;

public interface IParkingTariffRepository : IGenericRepositoryAsync<ParkingTariff>
{
    Task<ParkingTariff?> GetActiveAsync();
    Task<IEnumerable<ParkingTariff>> GetAllActiveAsync();
}