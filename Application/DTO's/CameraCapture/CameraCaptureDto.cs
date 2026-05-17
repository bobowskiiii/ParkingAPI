using Domain.Entities;

namespace AppCore.DTO_s;

public record CameraCaptureDto(
    Guid Id,
    string LicensePlate,
    string Brand,
    string Color,
    string GateName,
    string? PathImage = null
)

{
    public static implicit operator CameraCaptureDto(CameraCapture entity) =>
        new(
            entity.Id,
            entity.LicensePlate,
            entity.DetectedBrand,
            entity.DetectedColor,
            entity.GateName,
            entity.ImagePath
        );  
}