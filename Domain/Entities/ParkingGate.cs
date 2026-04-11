using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class ParkingGate : EntityBase
{
    public string Name { get; private set; }
    public GateType Type { get; private set; }
    public string Location { get; private set; }
    public bool IsOperational { get; private set; }

    public ICollection<ParkingSession> Sessions { get; set; } = [];
    public ICollection<CameraCapture> Captures { get; set; } = [];
    
    private ParkingGate() { }
    public ParkingGate(string name, GateType type, string location)
    {
        Name = name;
        Type = type;
        Location = location;
        IsOperational = true;
    }
    
        
}   