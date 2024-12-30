using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalThesis.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CityController(CityService cityService) : ControllerBase
{
    private readonly CityService _cityService = cityService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BLCity>>> GetCities()
    {
        var cities = await _cityService.GetAllCitiesAsync();
        return Ok(cities);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BLCity>> GetCity(int id)
    {
        var city = await _cityService.GetCityByIdAsync(id);
        if (city == null) return NotFound();
        return Ok(city);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCity(BLCity blCity)
    {
        await _cityService.AddCityAsync(blCity);
        return CreatedAtAction(nameof(CreateCity), new { id = blCity.IDCity }, blCity);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCity(int id, BLCity blCity)
    {
        if (id != blCity.IDCity) 
            return BadRequest();
        await _cityService.UpdateCityAsync(blCity);
        var updatedCity = await _cityService.GetCityByIdAsync(id);
        return Ok(updatedCity);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCity(int id)
    {
        var cityToDelete = await _cityService.GetCityByIdAsync(id);
        if (cityToDelete == null) 
            return NotFound();
        await _cityService.DeleteCityAsync(id);
        return Ok(cityToDelete);
    }
}
