using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalThesis.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConnectionTypeController(ConnectionTypeService connectionTypeService) : ControllerBase
{
    private readonly ConnectionTypeService _connectionTypeService = connectionTypeService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BLConnectionType>>> GetConnectionTypes()
    {
        var connectionTypes = await _connectionTypeService.GetAllConnectionTypesAsync();
        return Ok(connectionTypes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BLConnectionType>> GetConnectionType(int id)
    {
        var connectionType = await _connectionTypeService.GetConnectionTypeByIdAsync(id);
        if (connectionType == null)
            return NotFound();
        return Ok(connectionType);
    }

    [HttpPost]
    public async Task<IActionResult> CreateConnectionType(BLConnectionType blConnectionType)
    {
        await _connectionTypeService.AddConnectionTypeAsync(blConnectionType);
        return CreatedAtAction(nameof(CreateConnectionType), new { id = blConnectionType.IDConnectionType }, blConnectionType);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateConnectionType(int id, BLConnectionType blConnectionType)
    {
        if (id != blConnectionType.IDConnectionType)
            return BadRequest();
        await _connectionTypeService.UpdateConnectionTypeAsync(blConnectionType);
        var updatedConnectionType = await _connectionTypeService.GetConnectionTypeByIdAsync(id);
        return Ok(updatedConnectionType);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteConnectionType(int id)
    {
        var connectionTypeToDelete = await _connectionTypeService.GetConnectionTypeByIdAsync(id);
        if (connectionTypeToDelete == null)
            return NotFound();
        await _connectionTypeService.DeleteConnectionTypeAsync(id);
        return Ok(connectionTypeToDelete);
    }
}
