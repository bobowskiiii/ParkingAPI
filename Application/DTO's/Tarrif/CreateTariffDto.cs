namespace AppCore.DTO_s.Tarrif;

public record CreateTariffDto
(
    string Name,
    int FreeMinutes,
    decimal HourlyRate,
    decimal DailyMaxRate
);