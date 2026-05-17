using Domain.Entities;
using Domain.Enums;

namespace AppCore.DTO_s;

public record CameraCaptureCreateDto(
    string LicensePlate,
    string DetectedBrand,
    string DetectedColor,
    string ImagePath,
    string CaptureType
)
{
    public CameraCapture ToEntity(Guid parkingGateId, string gateName) => new CameraCapture(
        gateName,
        LicensePlate,
        DetectedBrand,
        DetectedColor,
        ImagePath,
        Enum.Parse<CaptureType>(CaptureType, ignoreCase: true),
        parkingGateId
    );
}