using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalThesis.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BankController(BankService bankService) : ControllerBase
{
    private readonly BankService _bankService = bankService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BLBank>>> GetBanks()
    {
        var banks = await _bankService.GetAllBanksAsync();
        return Ok(banks);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BLCity>> GetBank(int id)
    {
        var bank = await _bankService.GetBankByIdAsync(id);
        if (bank == null) 
            return NotFound();
        return Ok(bank);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBank(BLBank blBank)
    {
        await _bankService.AddBankAsync(blBank);
        return CreatedAtAction(nameof(CreateBank), new { id = blBank.IDBank }, blBank);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBank(int id, BLBank blBank)
    {
        if (id != blBank.IDBank)
            return BadRequest();
        await _bankService.UpdateBankAsync(blBank);
        var updatedBank = await _bankService.GetBankByIdAsync(id);
        return Ok(updatedBank);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBank(int id)
    {
        var bankToDelete = await _bankService.GetBankByIdAsync(id);
        if (bankToDelete == null)
            return NotFound();
        await _bankService.DeleteBankAsync(id);
        return Ok(bankToDelete);
    }
}
