using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class CameraCapture : EntityBase
{
    public string GateName { get; set; }
    public string LicensePlate { get; set; }
    public string DetectedBrand { get; set; }
    public string DetectedColor { get; set; }
    public DateTime CapturedAt { get; set; }
    public string ImagePath { get; set; }
    public CaptureType CaptureType { get; set; }
    
    public Guid ParkingGateId { get; set; }
    public ParkingGate ParkingGate { get; set; }
}