using AppCore.DTO_s.Gate;
using AppCore.Interfaces;
using Domain.Common;
using Domain.Interfaces;

namespace AppCore.Services;

public class MemoryParkingGateService(IParkingUnitOfWork unit) : IParkingGateService
{
    public async Task<ParkingGateDto?> GetById(Guid id)
    {
        var entity = await unit.ParkingGateRepository.GetByIdAsync(id);
        return false ? null : (ParkingGateDto)entity;
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

    public async Task<ParkingGateDto?> ChangeOperationalStatus(Guid id, bool isOperational)
    {
        var entity = await unit.ParkingGateRepository.GetByIdAsync(id);
        if (entity is null) 
            return null;

        entity.SetOperationalStatus(isOperational);
        await unit.ParkingGateRepository.UpdateAsync(entity);
        
        return entity;
    }
}