using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using FinalThesis.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalThesis.MVC.Controllers;

public class CountryController(CountryService countryService, IMapper mapper) : Controller
{
    private readonly CountryService _countryService = countryService;
    private readonly IMapper _mapper = mapper;

    public async Task<IActionResult> Index()
    {
        var blCountries = await _countryService.GetAllCountriesAsync();
        var vmCountries = _mapper.Map<IEnumerable<VMCountry>>(blCountries);
        return View(vmCountries);
    }

    public async Task<IActionResult> Details(int id)
    {
        var blCountry = await _countryService.GetCountryByIdAsync(id);
        if (blCountry == null)
            return NotFound();
        var vmCountry = _mapper.Map<VMCountry>(blCountry);
        return View(vmCountry);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(VMCountry vmCountry)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var blCountry = _mapper.Map<BLCountry>(vmCountry);
                await _countryService.AddCountryAsync(blCountry);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
        }
        return View(vmCountry);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var blCountry = await _countryService.GetCountryByIdAsync(id);
        if (blCountry == null)
            return NotFound();
        var vmCountry = _mapper.Map<VMCountry>(blCountry);
        return View(vmCountry);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, VMCountry vmCountry)
    {
        if (id != vmCountry.IDCountry)
            return BadRequest();

        if (ModelState.IsValid)
        {
            var blCountry = _mapper.Map<BLCountry>(vmCountry);
            await _countryService.UpdateCountryAsync(blCountry);
            return RedirectToAction(nameof(Index));
        }
        return View(vmCountry);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var blCountry = await _countryService.GetCountryByIdAsync(id);
        if (blCountry == null)
            return NotFound();
        var vmCountry = _mapper.Map<VMCountry>(blCountry);
        return View(vmCountry);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id, VMCountry vmCountry)
    {
        await _countryService.DeleteCountryAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
