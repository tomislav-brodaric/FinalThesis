using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalThesis.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountryController(CountryService countryService) : ControllerBase
{
    private readonly CountryService _countryService = countryService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BLCountry>>> GetCountries()
    {
        var countries = await _countryService.GetAllCountriesAsync();
        return Ok(countries);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BLCountry>> GetCountry(int id)
    {
        var country = await _countryService.GetCountryByIdAsync(id);
        if (country == null) return NotFound();
        return Ok(country);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCountry(BLCountry blCountry)
    {
        await _countryService.AddCountryAsync(blCountry);
        return CreatedAtAction(nameof(CreateCountry), new { id = blCountry.IDCountry}, blCountry);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCountry(int id, BLCountry blCountry)
    {
        if (id != blCountry.IDCountry)
            return BadRequest();
        await _countryService.UpdateCountryAsync(blCountry);
        var updatedCity = await _countryService.GetCountryByIdAsync(id);
        return Ok(updatedCity);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCountry(int id)
    {
        var countryToDelete = await _countryService.GetCountryByIdAsync(id);
        if (countryToDelete == null)
            return NotFound();
        await _countryService.DeleteCountryAsync(id);
        return Ok(countryToDelete);
    }
}