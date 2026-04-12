using Domain.Entities;

namespace AppCore.DTO_s.Gate;

public record ParkingGateDto(
    Guid Id,
    string Name,
    string Type,
    string Location,
    bool IsOperational
)

{
    public static implicit operator ParkingGateDto(ParkingGate gate)
    {
        return new ParkingGateDto(
            gate.Id,
            gate.Name,
            gate.Type.ToString(),
            gate.Location,
            gate.IsOperational
        );
    }
}