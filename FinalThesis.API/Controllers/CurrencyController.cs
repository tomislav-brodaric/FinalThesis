using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalThesis.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CurrencyController(CurrencyService currencyService) : Controller
{
    private readonly CurrencyService _currencyService = currencyService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BLCurrency>>> GetCurrencies()
    {
        var currencies = await _currencyService.GetAllCurrenciesAsync();
        return Ok(currencies);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BLCurrency>> GetCurrency(int id)
    {
        var currency = await _currencyService.GetCurrencyByIdAsync(id);
        if (currency == null)
        {
            return NotFound();
        }
        return Ok(currency);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCurrency(BLCurrency blCurrency)
    {
        await _currencyService.AddCurrencyAsync(blCurrency);
        return CreatedAtAction(nameof(CreateCurrency), new { id = blCurrency.IDCurrency }, blCurrency);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCurrency(int id, BLCurrency blCurrency)
    {
        if (id != blCurrency.IDCurrency)
        {
            return BadRequest();
        }

        await _currencyService.UpdateCurrencyAsync(blCurrency);
        var updatedCurrency = await _currencyService.GetCurrencyByIdAsync(id);
        return Ok(updatedCurrency);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCurrency(int id)
    {
        var currencyToDelete = await _currencyService.GetCurrencyByIdAsync(id);
        if (currencyToDelete == null)
        {
            return NotFound();
        }

        await _currencyService.DeleteCurrencyAsync(id);
        return Ok(currencyToDelete);
    }
}