using AppCore.DTO_s;
using AppCore.DTO_s.Gate;
using Domain.Common;
using Domain.Entities;

namespace AppCore.Interfaces;

public interface IParkingGateService
{
    Task<ParkingGateDto?> GetById (Guid id);
    Task<ParkingGateDto?> GetByName (string name);
    Task<PagedResult<ParkingGateDto>> GetAllPaged (int page, int pageSize);
    Task<ParkingGateDto> Add (CreateGateDto dto);
    Task<ParkingGateDto?> Update(Guid id, UpdateGateDto dto);
    Task<ParkingGateDto?> ChangeOperationalStatus (Guid id, bool isOperational);
    Task<CameraCaptureDto> AddCapture(Guid gateId, CameraCaptureCreateDto captureDto);
    Task<PagedResult<CameraCaptureDto>>GetCaptures(Guid gateId, int page, int pageSize);
    Task DeleteCapture(Guid captureId, Guid gateId);
}