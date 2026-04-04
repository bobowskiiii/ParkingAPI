namespace AppCore.DTO_s;

public record ParkingEntryResultDto
(
    Guid SessionId,
    VehicleDto Vehicle,
    string GateName,
    DateTime EntryTime,
    string Message
);