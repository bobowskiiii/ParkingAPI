using Domain.Entities;

namespace AppCore.DTO_s.Tarrif;

public record ParkingTariffDto(
    Guid Id,
    string Name,
    TimeSpan FreeParkingDuration,
    decimal HourlyRate,
    decimal DailyMaxRate,
    bool IsActive
)

{
    public static implicit operator ParkingTariffDto(ParkingTariff tariff) =>
        new(
            tariff.Id,
            tariff.Name,
            tariff.FreeParkingDuration,
            tariff.HourlyRate,
            tariff.DailyMaxRate,
            tariff.IsActive
        );
}