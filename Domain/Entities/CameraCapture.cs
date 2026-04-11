using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class CameraCapture : EntityBase
{
    public string GateName { get; private set; }
    public string LicensePlate { get; private set; }
    public string DetectedBrand { get; private set; }
    public string DetectedColor { get; private set; }
    public DateTime CapturedAt { get; private set; }
    public string ImagePath { get; private set; }
    public CaptureType CaptureType { get; private set; }
    
    public Guid ParkingGateId { get; private set; }
    public ParkingGate ParkingGate { get; private set; }
    
    private CameraCapture() { }

    public CameraCapture(string gateName, string licensePlate, string detectedBrand, string detectedColor,
        DateTime capturedAt, string imagePath, CaptureType captureType, Guid parkingGateId)
    {
        GateName = gateName;
        LicensePlate = licensePlate;
        DetectedBrand = detectedBrand;
        DetectedColor = detectedColor;
        CapturedAt = capturedAt;
        ImagePath = imagePath;
        CaptureType = captureType;
        ParkingGateId = parkingGateId;
    }
}