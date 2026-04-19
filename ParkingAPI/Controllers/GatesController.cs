using AppCore.DTO_s.Gate;
using AppCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ParkingAPI.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class GatesController(IParkingGateService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllGates([FromQuery] int page = 1, [FromQuery] int size = 10)
    {
        return Ok(await service.GetAllPaged(page, size));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await service.GetById(id);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet("name/{name}")]
    public async Task<IActionResult> GetByName(string name)
    {
        var result = await service.GetByName(name);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateGateDto dto)
    {
        var result = await service.Add(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateGateDto dto)
    {
        var result = await service.Update(id, dto);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPatch("{id:guid}/status")]
    public async Task<IActionResult> ChangeStatus(Guid id, [FromQuery] bool isOperational)
    {
        var result = await service.ChangeOperationalStatus(id, isOperational);
        return result is null ? NotFound() : Ok(result);
    }
}