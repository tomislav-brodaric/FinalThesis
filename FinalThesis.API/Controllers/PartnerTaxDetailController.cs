using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalThesis.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PartnerTaxDetailController(PartnerTaxDetailService taxDetailService) : ControllerBase
{
    private readonly PartnerTaxDetailService _taxDetailService = taxDetailService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BLPartnerTaxDetail>>> GetTaxDetails()
    {
        var taxDetails = await _taxDetailService.GetAllTaxDetailsAsync();
        return Ok(taxDetails);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BLPartnerTaxDetail>> GetTaxDetail(int id)
    {
        var taxDetail = await _taxDetailService.GetTaxDetailByIdAsync(id);
        if (taxDetail == null) return NotFound();
        return Ok(taxDetail);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTaxDetail(BLPartnerTaxDetail blTaxDetail)
    {
        await _taxDetailService.AddTaxDetailAsync(blTaxDetail);
        return CreatedAtAction(nameof(CreateTaxDetail), new { id = blTaxDetail.IDTaxDetail }, blTaxDetail);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTaxDetail(int id, BLPartnerTaxDetail blTaxDetail)
    {
        if (id != blTaxDetail.IDTaxDetail) return BadRequest();
        await _taxDetailService.UpdateTaxDetailAsync(blTaxDetail);
        var updatedTaxDetail = await _taxDetailService.GetTaxDetailByIdAsync(id);
        return Ok(updatedTaxDetail);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTaxDetail(int id)
    {
        var taxDetailToDelete = await _taxDetailService.GetTaxDetailByIdAsync(id);
        if (taxDetailToDelete == null) return NotFound();
        await _taxDetailService.DeleteTaxDetailAsync(id);
        return Ok(taxDetailToDelete);
    }
}
