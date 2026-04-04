namespace AppCore.DTO_s;

public record CameraCaptureDto
(
    string LicensePlate,
    string Brand,
    string Color,
    string GateName,
    string? PathImage = null
);