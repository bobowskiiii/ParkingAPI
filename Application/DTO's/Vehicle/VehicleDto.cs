using Domain.Entities;

namespace AppCore.DTO_s;

public record VehicleDto
(
    Guid Id,
    string LicensePlate,
    string Brand,
    string Color
)

{
    public static implicit operator VehicleDto(Vehicle entity) =>
        new(
            entity.Id,
            entity.LicensePlate,
            entity.Brand,
            entity.Color
        );
}