using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalThesis.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PartnerController(PartnerService partnerService) : ControllerBase
{
    private readonly PartnerService _partnerService = partnerService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BLPartner>>> GetPartners()
    {
        var partners = await _partnerService.GetAllPartnersAsync();
        return Ok(partners);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BLPartner>> GetPartner(int id)
    {
        var partner = await _partnerService.GetPartnerByIdAsync(id);
        if (partner == null) return NotFound();
        return Ok(partner);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePartner(BLPartner blPartner)
    {
        await _partnerService.AddPartnerAsync(blPartner);
        return CreatedAtAction(nameof(CreatePartner), new { id = blPartner.IDPartner }, blPartner);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePartner(int id, BLPartner blPartner)
    {
        if (id != blPartner.IDPartner) return BadRequest();
        await _partnerService.UpdatePartnerAsync(blPartner);
        var updatedPartner = await _partnerService.GetPartnerByIdAsync(id);
        return Ok(updatedPartner);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePartner(int id)
    {
        var partnerToDelete = await _partnerService.GetPartnerByIdAsync(id);
        if (partnerToDelete == null) return NotFound();
        await _partnerService.DeletePartnerAsync(id);
        return Ok(partnerToDelete);
    }
}
