using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalThesis.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VATPaymentMethodController(VATPaymentMethodService vatPaymentMethodService) : ControllerBase
{
    private readonly VATPaymentMethodService _vatPaymentMethodService = vatPaymentMethodService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BLVATPaymentMethod>>> GetVATPaymentMethods()
    {
        var vatPaymentMethods = await _vatPaymentMethodService.GetAllVATPaymentMethodsAsync();
        return Ok(vatPaymentMethods);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BLVATPaymentMethod>> GetVATPaymentMethod(int id)
    {
        var vatPaymentMethod = await _vatPaymentMethodService.GetVATPaymentMethodByIdAsync(id);
        if (vatPaymentMethod == null) return NotFound();
        return Ok(vatPaymentMethod);
    }

    [HttpPost]
    public async Task<IActionResult> CreateVATPaymentMethod(BLVATPaymentMethod blVATPaymentMethod)
    {
        await _vatPaymentMethodService.AddVATPaymentMethodAsync(blVATPaymentMethod);
        return CreatedAtAction(nameof(CreateVATPaymentMethod), new { id = blVATPaymentMethod.IDVATPaymentMethod }, blVATPaymentMethod);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVATPaymentMethod(int id, BLVATPaymentMethod blVATPaymentMethod)
    {
        if (id != blVATPaymentMethod.IDVATPaymentMethod) return BadRequest();
        await _vatPaymentMethodService.UpdateVATPaymentMethodAsync(blVATPaymentMethod);
        var updatedVATPaymentMethod = await _vatPaymentMethodService.GetVATPaymentMethodByIdAsync(id);
        return Ok(updatedVATPaymentMethod);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVATPaymentMethod(int id)
    {
        var vatPaymentMethodToDelete = await _vatPaymentMethodService.GetVATPaymentMethodByIdAsync(id);
        if (vatPaymentMethodToDelete == null) return NotFound();
        await _vatPaymentMethodService.DeleteVATPaymentMethodAsync(id);
        return Ok(vatPaymentMethodToDelete);
    }
}
