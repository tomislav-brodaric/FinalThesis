using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalThesis.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InvoiceProductController(InvoiceProductService invoiceProductService) : ControllerBase
{
    private readonly InvoiceProductService _invoiceProductService = invoiceProductService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BLInvoiceProduct>>> GetInvoiceProducts()
    {
        var products = await _invoiceProductService.GetAllInvoiceProductsAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BLInvoiceProduct>> GetInvoiceProduct(int id)
    {
        var product = await _invoiceProductService.GetInvoiceProductByIdAsync(id);
        if (product == null)
            return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> CreateInvoiceProduct(BLInvoiceProduct product)
    {
        await _invoiceProductService.AddInvoiceProductAsync(product);
        return CreatedAtAction(nameof(CreateInvoiceProduct), new { id = product.IDInvoiceProduct }, product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateInvoiceProduct(int id, BLInvoiceProduct product)
    {
        if (id != product.IDInvoiceProduct)
            return BadRequest();
        await _invoiceProductService.UpdateInvoiceProductAsync(product);
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInvoiceProduct(int id)
    {
        var product = await _invoiceProductService.GetInvoiceProductByIdAsync(id);
        if (product == null)
            return NotFound();
        await _invoiceProductService.DeleteInvoiceProductAsync(id);
        return Ok(product);
    }
}
