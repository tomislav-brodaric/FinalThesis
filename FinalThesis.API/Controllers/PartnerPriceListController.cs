using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalThesis.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PartnerPriceListController(PartnerPriceListService priceListService) : ControllerBase
{
    private readonly PartnerPriceListService _priceListService = priceListService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BLPartnerPriceList>>> GetPriceLists()
    {
        var priceLists = await _priceListService.GetAllPriceListsAsync();
        return Ok(priceLists);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BLPartnerPriceList>> GetPriceList(int id)
    {
        var priceList = await _priceListService.GetPriceListByIdAsync(id);
        if (priceList == null) return NotFound();
        return Ok(priceList);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePriceList(BLPartnerPriceList blPriceList)
    {
        await _priceListService.AddPriceListAsync(blPriceList);
        return CreatedAtAction(nameof(CreatePriceList), new { id = blPriceList.IDPriceList }, blPriceList);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePriceList(int id, BLPartnerPriceList blPriceList)
    {
        if (id != blPriceList.IDPriceList) return BadRequest();
        await _priceListService.UpdatePriceListAsync(blPriceList);
        var updatedPriceList = await _priceListService.GetPriceListByIdAsync(id);
        return Ok(updatedPriceList);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePriceList(int id)
    {
        var priceListToDelete = await _priceListService.GetPriceListByIdAsync(id);
        if (priceListToDelete == null) return NotFound();
        await _priceListService.DeletePriceListAsync(id);
        return Ok(priceListToDelete);
    }
}
