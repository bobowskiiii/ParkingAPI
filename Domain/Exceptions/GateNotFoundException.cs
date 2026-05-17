namespace Domain.Exceptions;

public class GateNotFoundException : Exception
{
    public GateNotFoundException(string msg) : base(msg){ }
}