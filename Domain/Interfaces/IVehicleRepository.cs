using Domain.Common;
using Domain.Entities;

namespace Infrastructure.Repositories;

public interface IVehicleRepository : IGenericRepositoryAsync<Vehicle>
{
    Task<Vehicle?> GetByLicensPlateAsync(string licensePlate);
}