using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalThesis.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OfferProductController(OfferProductService offerProductService) : ControllerBase
{
    private readonly OfferProductService _offerProductService = offerProductService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BLOfferProduct>>> GetOfferProducts()
    {
        var products = await _offerProductService.GetAllOfferProductsAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BLOfferProduct>> GetOfferProduct(int id)
    {
        var product = await _offerProductService.GetOfferProductByIdAsync(id);
        if (product == null)
            return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOfferProduct(BLOfferProduct product)
    {
        await _offerProductService.AddOfferProductAsync(product);
        return CreatedAtAction(nameof(CreateOfferProduct), new { id = product.IDOfferProduct }, product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOfferProduct(int id, BLOfferProduct product)
    {
        if (id != product.IDOfferProduct)
            return BadRequest();
        await _offerProductService.UpdateOfferProductAsync(product);
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOfferProduct(int id)
    {
        var product = await _offerProductService.GetOfferProductByIdAsync(id);
        if (product == null)
            return NotFound();
        await _offerProductService.DeleteOfferProductAsync(id);
        return Ok(product);
    }
}
