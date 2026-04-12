using Domain.Common;
using Domain.Entities;

namespace Domain.Interfaces;

public interface IVehicleRepository : IGenericRepositoryAsync<Vehicle>
{
    Task<Vehicle?> GetByLicensPlateAsync(string licensePlate);
}