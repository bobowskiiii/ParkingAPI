using Domain.Common;
using Domain.Entities;

namespace Domain.Interfaces;

public interface ICameraCaptureRepository : IGenericRepositoryAsync<CameraCapture>
{
    Task<IEnumerable<CameraCapture>> FindByLicensePlateAsync(string licensePlate);
    Task<IEnumerable<CameraCapture>> FindByGateNameAsync(string gateName);
}