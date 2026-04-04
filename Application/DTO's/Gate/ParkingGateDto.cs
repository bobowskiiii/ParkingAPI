namespace AppCore.DTO_s.Gate;

public record ParkingGateDto
(
    Guid Id,
    string Name,
    string Type,
    string Location,
    bool IsOperational
);