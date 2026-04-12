namespace AppCore.DTO_s;

public record ActiveParkingSessionDto
(
    Guid SessionId,
    VehicleDto Vehicle,
    string GateName,
    DateTime EntryTime,
    TimeSpan CurrentDuration
);