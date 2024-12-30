using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalThesis.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdvanceInvoicePaymentController(AdvanceInvoicePaymentService paymentService) : ControllerBase
{
    private readonly AdvanceInvoicePaymentService _paymentService = paymentService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BLAdvanceInvoicePayment>>> GetPayments()
    {
        var payments = await _paymentService.GetAllPaymentsAsync();
        return Ok(payments);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BLAdvanceInvoicePayment>> GetPayment(int id)
    {
        var payment = await _paymentService.GetPaymentByIdAsync(id);
        if (payment == null)
            return NotFound();
        return Ok(payment);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePayment(BLAdvanceInvoicePayment blPayment)
    {
        await _paymentService.AddPaymentAsync(blPayment);
        return CreatedAtAction(nameof(CreatePayment), new { id = blPayment.IDAdvanceInvoicePayment }, blPayment);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePayment(int id, BLAdvanceInvoicePayment blPayment)
    {
        if (id != blPayment.IDAdvanceInvoicePayment)
            return BadRequest();
        await _paymentService.UpdatePaymentAsync(blPayment);
        var updatedPayment = await _paymentService.GetPaymentByIdAsync(id);
        return Ok(updatedPayment);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePayment(int id)
    {
        var paymentToDelete = await _paymentService.GetPaymentByIdAsync(id);
        if (paymentToDelete == null)
            return NotFound();
        await _paymentService.DeletePaymentAsync(id);
        return Ok(paymentToDelete);
    }
}
