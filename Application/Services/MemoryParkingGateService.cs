using AppCore.DTO_s;
using AppCore.DTO_s.Gate;
using AppCore.Interfaces;
using Domain.Common;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;

namespace AppCore.Services;

public class MemoryParkingGateService(IParkingUnitOfWork unit) : IParkingGateService
{
    public async Task<ParkingGateDto?> GetById(Guid id)
    {
        var entity = await unit.ParkingGateRepository.GetByIdAsync(id);
        return entity is null ? null : (ParkingGateDto)entity;
    }

    public async Task<ParkingGateDto?> GetByName(string name)
    {
        var entity = await unit.ParkingGateRepository.GetByNameAsync(name);
        return entity is null ? null : (ParkingGateDto)entity;    
    }

    public async Task<PagedResult<ParkingGateDto>> GetAllPaged(int page, int pageSize)
    {
        var paged = await unit.ParkingGateRepository.GetPagedAsync(page, pageSize);
        var items = paged.Items
            .Select(g => (ParkingGateDto)g)
            .ToList();
        
        return new PagedResult<ParkingGateDto>(items, paged.TotalCount, page, pageSize);
    }

    public async Task<ParkingGateDto> Add(CreateGateDto dto)
    {
        var entity = dto.ToEntity;
        await unit.ParkingGateRepository.AddAsync(entity);
        
        return entity;
    }

    public async Task<ParkingGateDto?> Update(Guid id, UpdateGateDto dto)
    {
        var entity = await unit.ParkingGateRepository.GetByIdAsync(id);
        if (entity is null)
            return null;

        var type = Enum.Parse<Domain.Enums.GateType>(dto.Type, true);
        entity.Update(dto.Name, type);
        
        await unit.ParkingGateRepository.UpdateAsync(entity);
        return entity;
    }

    public async Task<ParkingGateDto?> ChangeOperationalStatus(Guid id, bool isOperational)
    {
        var entity = await unit.ParkingGateRepository.GetByIdAsync(id);
        if (entity is null) 
            return null;

        entity.SetOperationalStatus(isOperational);
        await unit.ParkingGateRepository.UpdateAsync(entity);
        
        return entity;
    }

    public async Task<CameraCaptureDto> AddCapture(Guid gateId, CameraCaptureCreateDto captureDto)
    {
        var gate = await unit.ParkingGateRepository.GetByIdAsync(gateId);
        if (gate is null)
            throw new GateNotFoundException("Gate not found");
        
        var capture = captureDto.ToEntity(gateId, gate.Name);
        await unit.CameraCaptureRepository.AddAsync(capture);
        
        return (CameraCaptureDto)capture;
    }

    public async Task<PagedResult<CameraCaptureDto>> GetCaptures(Guid gateId, int page, int pageSize)
    {
        var captures = await unit.CameraCaptureRepository.FindByGateIdAsync(gateId);
        
        var items = captures
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(c => (CameraCaptureDto)c)
            .ToList();
        
        return new PagedResult<CameraCaptureDto>(items, captures.Count(), page, pageSize);
    }

    public async Task DeleteCapture(Guid captureId, Guid gateId)
    {
        var gate = await unit.ParkingGateRepository.GetByIdAsync(gateId);
        if (gate is null)
            throw new GateNotFoundException($"Gate {gateId} not found");
        
        await unit.CameraCaptureRepository.DeleteAsync(captureId);
    }
}