using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalThesis.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdvanceInvoiceController(AdvanceInvoiceService advanceInvoiceService) : ControllerBase
{
    private readonly AdvanceInvoiceService _advanceInvoiceService = advanceInvoiceService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BLAdvanceInvoice>>> GetAdvanceInvoices()
    {
        var invoices = await _advanceInvoiceService.GetAllAdvanceInvoicesAsync();
        return Ok(invoices);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BLAdvanceInvoice>> GetAdvanceInvoice(int id)
    {
        var invoice = await _advanceInvoiceService.GetAdvanceInvoiceByIdAsync(id);
        if (invoice == null)
            return NotFound();
        return Ok(invoice);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAdvanceInvoice(BLAdvanceInvoice invoice)
    {
        await _advanceInvoiceService.AddAdvanceInvoiceAsync(invoice);
        return CreatedAtAction(nameof(CreateAdvanceInvoice), new { id = invoice.IDAdvanceInvoice }, invoice);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAdvanceInvoice(int id, BLAdvanceInvoice invoice)
    {
        if (id != invoice.IDAdvanceInvoice)
            return BadRequest();
        await _advanceInvoiceService.UpdateAdvanceInvoiceAsync(invoice);
        return Ok(invoice);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAdvanceInvoice(int id)
    {
        var invoice = await _advanceInvoiceService.GetAdvanceInvoiceByIdAsync(id);
        if (invoice == null)
            return NotFound();
        await _advanceInvoiceService.DeleteAdvanceInvoiceAsync(id);
        return Ok(invoice);
    }
}
