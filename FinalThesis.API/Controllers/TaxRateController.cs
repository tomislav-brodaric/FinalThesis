using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalThesis.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaxRateController(TaxRateService taxRateService) : ControllerBase
{
    private readonly TaxRateService _taxRateService = taxRateService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BLTaxRate>>> GetTaxRates()
    {
        var taxRates = await _taxRateService.GetAllTaxRatesAsync();
        return Ok(taxRates);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BLTaxRate>> GetTaxRate(int id)
    {
        var taxRate = await _taxRateService.GetTaxRateByIdAsync(id);
        if (taxRate == null)
            return NotFound();
        return Ok(taxRate);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTaxRate(BLTaxRate blTaxRate)
    {
        await _taxRateService.AddTaxRateAsync(blTaxRate);
        return CreatedAtAction(nameof(CreateTaxRate), new { id = blTaxRate.IDTaxRate }, blTaxRate);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTaxRate(int id, BLTaxRate blTaxRate)
    {
        if (id != blTaxRate.IDTaxRate)
            return BadRequest();
        await _taxRateService.UpdateTaxRateAsync(blTaxRate);
        var updatedTaxRate = await _taxRateService.GetTaxRateByIdAsync(id);
        return Ok(updatedTaxRate);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTaxRate(int id)
    {
        var taxRateToDelete = await _taxRateService.GetTaxRateByIdAsync(id);
        if (taxRateToDelete == null)
            return NotFound();
        await _taxRateService.DeleteTaxRateAsync(id);
        return Ok(taxRateToDelete);
    }
}