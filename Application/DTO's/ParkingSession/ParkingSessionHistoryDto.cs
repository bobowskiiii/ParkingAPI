using Domain.Entities;

namespace AppCore.DTO_s;

public record ParkingSessionHistoryDto(
    Guid SessionId,
    VehicleDto Vehicle,
    string GateName,
    DateTime EntryTime,
    DateTime? ExitTime,
    TimeSpan? Duration,
    decimal? Fee,
    bool IsActive
)

{
    public static explicit operator ParkingSessionHistoryDto(ParkingSession entity) =>
        new(
            entity.Id,
            entity.Vehicle,
            entity.GateName,
            entity.EntryTime,
            entity.ExitTime,
            entity.Duration,
            entity.Fee,
            entity.IsActive
        );  
}