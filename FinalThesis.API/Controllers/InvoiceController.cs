using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalThesis.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InvoiceController(InvoiceService invoiceService) : ControllerBase
{
    private readonly InvoiceService _invoiceService = invoiceService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BLInvoice>>> GetInvoices()
    {
        var invoices = await _invoiceService.GetAllInvoicesAsync();
        return Ok(invoices);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BLInvoice>> GetInvoice(int id)
    {
        var invoice = await _invoiceService.GetInvoiceByIdAsync(id);
        if (invoice == null)
            return NotFound();
        return Ok(invoice);
    }

    [HttpPost]
    public async Task<IActionResult> CreateInvoice(BLInvoice invoice)
    {
        await _invoiceService.AddInvoiceAsync(invoice);
        return CreatedAtAction(nameof(CreateInvoice), new { id = invoice.IDInvoice }, invoice);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateInvoice(int id, BLInvoice invoice)
    {
        if (id != invoice.IDInvoice)
            return BadRequest();
        await _invoiceService.UpdateInvoiceAsync(invoice);
        return Ok(invoice);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInvoice(int id)
    {
        var invoice = await _invoiceService.GetInvoiceByIdAsync(id);
        if (invoice == null)
            return NotFound();
        await _invoiceService.DeleteInvoiceAsync(id);
        return Ok(invoice);
    }
}
