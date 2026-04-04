namespace AppCore.DTO_s;

public record ParkingSessionHistoryDto
(
    Guid SessionId,
    VehicleDto Vehicle,
    string GateName,
    DateTime EntryTime,
    DateTime? ExitTime, 
    TimeSpan? Duration,
    decimal? Fee,
    bool IsActive
);