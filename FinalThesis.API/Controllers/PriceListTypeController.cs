using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalThesis.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PriceListTypeController(PriceListTypeService priceListTypeService) : ControllerBase
{
    private readonly PriceListTypeService _priceListTypeService = priceListTypeService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BLPriceListType>>> GetPriceListTypes()
    {
        var priceListTypes = await _priceListTypeService.GetAllPriceListTypesAsync();
        return Ok(priceListTypes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BLPriceListType>> GetPriceListType(int id)
    {
        var priceListType = await _priceListTypeService.GetPriceListTypeByIdAsync(id);
        if (priceListType == null) return NotFound();
        return Ok(priceListType);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePriceListType(BLPriceListType blPriceListType)
    {
        await _priceListTypeService.AddPriceListTypeAsync(blPriceListType);
        return CreatedAtAction(nameof(CreatePriceListType), new { id = blPriceListType.IDPriceListType }, blPriceListType);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePriceListType(int id, BLPriceListType blPriceListType)
    {
        if (id != blPriceListType.IDPriceListType) return BadRequest();
        await _priceListTypeService.UpdatePriceListTypeAsync(blPriceListType);
        var updatedPriceListType = await _priceListTypeService.GetPriceListTypeByIdAsync(id);
        return Ok(updatedPriceListType);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePriceListType(int id)
    {
        var priceListTypeToDelete = await _priceListTypeService.GetPriceListTypeByIdAsync(id);
        if (priceListTypeToDelete == null) return NotFound();
        await _priceListTypeService.DeletePriceListTypeAsync(id);
        return Ok(priceListTypeToDelete);
    }
}
