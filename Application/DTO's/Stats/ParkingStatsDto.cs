namespace AppCore.DTO_s.Stats;

public record ParkingStatsDto
(
    int ActiveVehicles,
    decimal TotalRevenue,
    int TodayEntries,
    int TodayExits
);