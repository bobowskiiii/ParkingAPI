using Domain.Entities;

namespace AppCore.DTO_s;

public record ActiveParkingSessionDto(
    Guid SessionId,
    VehicleDto Vehicle,
    string GateName,
    DateTime EntryTime,
    TimeSpan CurrentDuration
)

{
    public static explicit operator ActiveParkingSessionDto(ParkingSession entity) =>
        new(
            entity.Id,
            entity.Vehicle,
            entity.GateName,
            entity.EntryTime,
            DateTime.UtcNow - entity.EntryTime
        );
}