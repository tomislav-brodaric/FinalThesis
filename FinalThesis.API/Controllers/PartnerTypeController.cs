using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalThesis.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PartnerTypeController(PartnerTypeService partnerTypeService) : ControllerBase
{
    private readonly PartnerTypeService _partnerTypeService = partnerTypeService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BLPartnerType>>> GetPartnerTypes()
    {
        var partnerTypes = await _partnerTypeService.GetAllPartnerTypesAsync();
        return Ok(partnerTypes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BLPartnerType>> GetPartnerType(int id)
    {
        var partnerType = await _partnerTypeService.GetPartnerTypeByIdAsync(id);
        if (partnerType == null) return NotFound();
        return Ok(partnerType);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePartnerType(BLPartnerType blPartnerType)
    {
        await _partnerTypeService.AddPartnerTypeAsync(blPartnerType);
        return CreatedAtAction(nameof(CreatePartnerType), new { id = blPartnerType.IDPartnerType }, blPartnerType);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePartnerType(int id, BLPartnerType blPartnerType)
    {
        if (id != blPartnerType.IDPartnerType) return BadRequest();
        await _partnerTypeService.UpdatePartnerTypeAsync(blPartnerType);
        var updatedPartnerType = await _partnerTypeService.GetPartnerTypeByIdAsync(id);
        return Ok(updatedPartnerType);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePartnerType(int id)
    {
        var partnerTypeToDelete = await _partnerTypeService.GetPartnerTypeByIdAsync(id);
        if (partnerTypeToDelete == null) return NotFound();
        await _partnerTypeService.DeletePartnerTypeAsync(id);
        return Ok(partnerTypeToDelete);
    }
}
