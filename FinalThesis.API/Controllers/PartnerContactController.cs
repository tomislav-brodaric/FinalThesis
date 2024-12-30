using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalThesis.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PartnerContactController(PartnerContactService partnerContactService) : ControllerBase
{
    private readonly PartnerContactService _partnerContactService = partnerContactService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BLPartnerContact>>> GetPartnerContacts()
    {
        var partnerContacts = await _partnerContactService.GetAllPartnerContactsAsync();
        return Ok(partnerContacts);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BLPartnerContact>> GetPartnerContact(int id)
    {
        var partnerContact = await _partnerContactService.GetPartnerContactByIdAsync(id);
        if (partnerContact == null) return NotFound();
        return Ok(partnerContact);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePartnerContact(BLPartnerContact blPartnerContact)
    {
        await _partnerContactService.AddPartnerContactAsync(blPartnerContact);
        return CreatedAtAction(nameof(CreatePartnerContact), new { id = blPartnerContact.IDContact }, blPartnerContact);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePartnerContact(int id, BLPartnerContact blPartnerContact)
    {
        if (id != blPartnerContact.IDContact) return BadRequest();
        await _partnerContactService.UpdatePartnerContactAsync(blPartnerContact);
        var updatedPartnerContact = await _partnerContactService.GetPartnerContactByIdAsync(id);
        return Ok(updatedPartnerContact);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePartnerContact(int id)
    {
        var partnerContactToDelete = await _partnerContactService.GetPartnerContactByIdAsync(id);
        if (partnerContactToDelete == null) return NotFound();
        await _partnerContactService.DeletePartnerContactAsync(id);
        return Ok(partnerContactToDelete);
    }
}
