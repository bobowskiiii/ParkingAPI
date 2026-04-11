using Domain.Common;

namespace Domain.Entities;

public class ParkingTariff : EntityBase
{
    public string Name { get; private set; }
    public TimeSpan FreeParkingDuration { get; private set; }
    public decimal HourlyRate { get; private set; }
    public decimal DailyMaxRate { get; private set; }
    public bool IsActive { get; private set; }

    public decimal CalculateFee(TimeSpan duration)
    {
        if (duration <= this.FreeParkingDuration)
            return 0;

        var billable = duration - FreeParkingDuration;
        var fee = (decimal)billable.TotalHours * HourlyRate;
        
        return Math.Min(fee, DailyMaxRate);
    }
    private ParkingTariff() { }
    public ParkingTariff(string name, TimeSpan freeParkingDuration, decimal hourlyRate, decimal dailyMaxRate)
    {
        Name = name;
        FreeParkingDuration = freeParkingDuration;
        HourlyRate = hourlyRate;
        DailyMaxRate = dailyMaxRate;
        IsActive = true;
    }
    
}