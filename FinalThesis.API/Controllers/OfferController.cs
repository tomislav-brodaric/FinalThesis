using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalThesis.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OfferController(OfferService offerService) : ControllerBase
{
    private readonly OfferService _offerService = offerService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BLOffer>>> GetOffers()
    {
        var offers = await _offerService.GetAllOffersAsync();
        return Ok(offers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BLOffer>> GetOffer(int id)
    {
        var offer = await _offerService.GetOfferByIdAsync(id);
        if (offer == null)
            return NotFound();
        return Ok(offer);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOffer(BLOffer offer)
    {
        await _offerService.AddOfferAsync(offer);
        return CreatedAtAction(nameof(CreateOffer), new { id = offer.IDOffer }, offer);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOffer(int id, BLOffer offer)
    {
        if (id != offer.IDOffer)
            return BadRequest();
        await _offerService.UpdateOfferAsync(offer);
        return Ok(offer);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOffer(int id)
    {
        var offer = await _offerService.GetOfferByIdAsync(id);
        if (offer == null)
            return NotFound();
        await _offerService.DeleteOfferAsync(id);
        return Ok(offer);
    }
}
