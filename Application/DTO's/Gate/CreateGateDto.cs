using Domain.Entities;
using Domain.Enums;

namespace AppCore.DTO_s.Gate;

public record CreateGateDto(
    string Name,
    string Type,
    string Location
)
{
    public ParkingGate ToEntity => new ParkingGate(
        Name,
        Enum.Parse<GateType>(Type),
        Location
    );
}