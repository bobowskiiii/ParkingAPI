using Domain.Common;
using Domain.Entities;

namespace Domain.Interfaces;

public interface IParkingSessionRepository : IGenericRepositoryAsync<ParkingSession>
{
    Task<ParkingSession?> FindByLicensePlateAsync(string licensePlate);
    Task<IEnumerable<ParkingSession>> FindAllActiveAsync();
    Task<IEnumerable<ParkingSession?>> FindHistoryByLicensePlateAsync(string licensePlate);
}