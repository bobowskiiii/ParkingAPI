using AppCore.DTO_s;
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
    
    [HttpPost("{gateId:guid}/captures")]
    [ProducesResponseType(typeof(CameraCaptureDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddCameraCapture(
        [FromRoute] Guid gateId,
        [FromBody] CameraCaptureCreateDto dto)
    {
        var capture = await service.AddCapture(gateId, dto);
        return CreatedAtAction(
            nameof(GetCaptures),
            new { gateId },
            capture);
    }

    [HttpGet("{gateId:guid}/captures")]
    [ProducesResponseType(typeof(IEnumerable<CameraCaptureDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCaptures(
        [FromRoute] Guid gateId,
        [FromQuery] int page = 1,
        [FromQuery] int size = 10)
    {
        var gate = await service.GetById(gateId);
        if (gate is null)
            return NotFound();

        var captures = await service.GetCaptures(gateId, 1, int.MaxValue);
        return Ok(captures);
    }
    
    [HttpDelete("{gateId:guid}/captures/{captureId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteCapture(Guid gateId, Guid captureId)
    {
        await service.DeleteCapture(captureId, gateId);
        return NoContent();
    }
}