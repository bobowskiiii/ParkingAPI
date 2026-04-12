namespace AppCore.DTO_s.Tarrif;

public record ParkingTariffDto
(
    Guid Id,
    string Name,
    TimeSpan FreeParkingDuration,
    decimal HourlyRate,
    decimal DailyMaxRate,
    bool IsActive
);