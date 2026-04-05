using Domain.Common;

namespace Domain.Entities;

public class ParkingTariff : EntityBase
{
    public string Name { get; set; }
    public TimeSpan FreeParkingDuration { get; set; }
    public decimal HourlyRate { get; set; }
    public decimal DailyMaxRate { get; set; }
    public bool IsActive { get; set; }

    public decimal CalculateFee(TimeSpan duration)
    {
        if (duration <= this.FreeParkingDuration)
            return 0;

        var billable = duration - FreeParkingDuration;
        var fee = (decimal)billable.TotalHours * HourlyRate;
        
        return Math.Min(fee, DailyMaxRate);
    }
    
}