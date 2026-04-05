using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class ParkingGate : EntityBase
{
    public string Name { get; set; }
    public GateType Type { get; set; }
    public string Location { get; set; }
    public bool IsOperational { get; set; }

    public ICollection<ParkingSession> Sessions { get; set; } = [];
    public ICollection<CameraCapture> Captures { get; set; } = [];
}   