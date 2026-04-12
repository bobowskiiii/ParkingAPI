using Domain.Common;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Memory;

public class InMemoryCameraCaptureRepository : MemoryGenericRepository<CameraCapture>, ICameraCaptureRepository
{
    public Task<IEnumerable<CameraCapture>> FindByLicensePlateAsync(string licensePlate)
    {
        var result = _data.Values
            .Where(c => c.LicensePlate
                .Equals(licensePlate, StringComparison.OrdinalIgnoreCase))
            .AsEnumerable();
        
        return Task.FromResult(result);
    }

    public Task<IEnumerable<CameraCapture>> FindByGateNameAsync(string gateName)
    {
        var result = _data.Values
            .Where(c => c.GateName
                .Equals(gateName, StringComparison.OrdinalIgnoreCase))
            .AsEnumerable();
        
        return Task.FromResult(result);
    }
}