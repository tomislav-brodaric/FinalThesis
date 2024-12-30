using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalThesis.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaxNumberController(TaxNumberService taxNumberService) : ControllerBase
{
    private readonly TaxNumberService _taxNumberService = taxNumberService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BLTaxNumber>>> GetTaxNumbers()
    {
        var taxNumbers = await _taxNumberService.GetAllTaxNumbersAsync();
        return Ok(taxNumbers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BLTaxNumber>> GetTaxNumber(int id)
    {
        var taxNumber = await _taxNumberService.GetTaxNumberByIdAsync(id);
        if (taxNumber == null)
            return NotFound();
        return Ok(taxNumber);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTaxNumber(BLTaxNumber blTaxNumber)
    {
        await _taxNumberService.AddTaxNumberAsync(blTaxNumber);
        return CreatedAtAction(nameof(CreateTaxNumber), new { id = blTaxNumber.IDTaxNumber }, blTaxNumber);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTaxNumber(int id, BLTaxNumber blTaxNumber)
    {
        if (id != blTaxNumber.IDTaxNumber)
            return BadRequest();
        await _taxNumberService.UpdateTaxNumberAsync(blTaxNumber);
        var updatedTaxNumber = await _taxNumberService.GetTaxNumberByIdAsync(id);
        return Ok(updatedTaxNumber);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTaxNumber(int id)
    {
        var taxNumberToDelete = await _taxNumberService.GetTaxNumberByIdAsync(id);
        if (taxNumberToDelete == null)
            return NotFound();
        await _taxNumberService.DeleteTaxNumberAsync(id);
        return Ok(taxNumberToDelete);
    }
}