using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalThesis.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaxNumberTypeController(TaxNumberTypeService taxNumberTypeService) : ControllerBase
{
    private readonly TaxNumberTypeService _taxNumberTypeService = taxNumberTypeService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BLTaxNumberType>>> GetTaxNumberTypes()
    {
        var taxNumberTypes = await _taxNumberTypeService.GetAllTaxNumberTypesAsync();
        return Ok(taxNumberTypes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BLTaxNumberType>> GetTaxNumberType(int id)
    {
        var taxNumberType = await _taxNumberTypeService.GetTaxNumberTypeByIdAsync(id);
        if (taxNumberType == null) return NotFound();
        return Ok(taxNumberType);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTaxNumberType(BLTaxNumberType blTaxNumberType)
    {
        await _taxNumberTypeService.AddTaxNumberTypeAsync(blTaxNumberType);
        return CreatedAtAction(nameof(CreateTaxNumberType), new { id = blTaxNumberType.IDTaxNumberType }, blTaxNumberType);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTaxNumberType(int id, BLTaxNumberType blTaxNumberType)
    {
        if (id != blTaxNumberType.IDTaxNumberType) return BadRequest();
        await _taxNumberTypeService.UpdateTaxNumberTypeAsync(blTaxNumberType);
        var updatedTaxNumberType = await _taxNumberTypeService.GetTaxNumberTypeByIdAsync(id);
        return Ok(updatedTaxNumberType);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTaxNumberType(int id)
    {
        var taxNumberTypeToDelete = await _taxNumberTypeService.GetTaxNumberTypeByIdAsync(id);
        if (taxNumberTypeToDelete == null) return NotFound();
        await _taxNumberTypeService.DeleteTaxNumberTypeAsync(id);
        return Ok(taxNumberTypeToDelete);
    }
}
