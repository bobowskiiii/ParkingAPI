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
        return new ParkingTariff()
        {
            Name = Name
            FreeParkingDuration = TimeSpan.FromMinutes(FreeMinutes), 
            HourlyRate, 
            DailyMaxRate);
        }
            
    }
}