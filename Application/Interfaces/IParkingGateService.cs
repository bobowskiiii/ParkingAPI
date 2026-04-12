using AppCore.DTO_s.Gate;
using Domain.Common;

namespace AppCore.Interfaces;

public interface IParkingGateService
{
    Task<ParkingGateDto?> GetById (Guid id);
    Task<ParkingGateDto?> GetByName (string name);
    Task<PagedResult<ParkingGateDto>> GetAllPaged (int page, int pageSize);
    Task<ParkingGateDto> Add (CreateGateDto dto);
    Task<ParkingGateDto?> ChangeOperationalStatus (Guid id, bool isOperational);
}