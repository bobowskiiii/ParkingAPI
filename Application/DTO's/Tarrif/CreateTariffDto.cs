using Domain.Entities;

namespace AppCore.DTO_s.Tarrif;

public record CreateTariffDto(
    string Name,
    int FreeMinutes,
    decimal HourlyRate,
    decimal DailyMaxRate
)
{
    public ParkingTariff ToEntity()
    {
        return new ParkingTariff(
            Name,
            TimeSpan.FromMinutes(FreeMinutes),
            HourlyRate,
            DailyMaxRate,
            isActive: false);
    }
}