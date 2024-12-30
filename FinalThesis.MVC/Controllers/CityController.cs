using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using FinalThesis.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalThesis.MVC.Controllers;

public class CityController(CityService cityService, CountryService countryService, IMapper mapper) : Controller
{
    private readonly CityService _cityService = cityService;
    private readonly CountryService _countryService = countryService;
    private readonly IMapper _mapper = mapper;

    public async Task<IActionResult> Index()
    {
        var blCities = await _cityService.GetAllCitiesAsync();
        var vmCities = _mapper.Map<IEnumerable<VMCity>>(blCities);
        return View(vmCities);
    }

    public async Task<IActionResult> Details(int id)
    {
        var blCity = await _cityService.GetCityByIdAsync(id);
        if (blCity == null) 
            return NotFound();
        var vmCity = _mapper.Map<VMCity>(blCity);
        return View(vmCity);
    }

    public async Task<IActionResult> Create(int? IDCountry = null)
    {
        var countries = await _countryService.GetAllCountriesAsync();
        ViewBag.CountryList = _mapper.Map<IEnumerable<VMCountry>>(countries)
            .Select(c => new SelectListItem
            {
                Value = c.IDCountry.ToString(),
                Text = c.ShortNameHr,
                Selected = (IDCountry.HasValue && c.IDCountry == IDCountry.Value)
            });

        var referer = Request.Headers["Referer"].ToString();
        var vmCity = new VMCity
        {
            ReturnUrl = !string.IsNullOrEmpty(referer) ? referer : Url.Action("Index", "City")
        };

        return View(vmCity);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(VMCity vmCity, string returnUrl)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var blCity = _mapper.Map<BLCity>(vmCity);
                await _cityService.AddCityAsync(blCity);

                return Redirect(vmCity.ReturnUrl);
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
        }

        var countries = await _countryService.GetAllCountriesAsync();
        ViewBag.CountryList = _mapper.Map<IEnumerable<VMCountry>>(countries)
            .Select(c => new SelectListItem
            {
                Value = c.IDCountry.ToString(),
                Text = c.ShortNameHr
            }).ToList();

        return View(vmCity);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var blCity = await _cityService.GetCityByIdAsync(id);
        if (blCity == null) 
            return NotFound();
        var vmCity = _mapper.Map<VMCity>(blCity);

        var countries = await _countryService.GetAllCountriesAsync();
        ViewBag.CountryList = _mapper.Map<IEnumerable<VMCountry>>(countries)
            .Select(c => new SelectListItem
            {
                Value = c.IDCountry.ToString(),
                Text = c.ShortNameHr
            }).ToList();

        return View(vmCity);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, VMCity vmCity)
    {
        if (id != vmCity.IDCity) 
            return BadRequest();

        if (ModelState.IsValid)
        {
            var blCity = _mapper.Map<BLCity>(vmCity);
            await _cityService.UpdateCityAsync(blCity);
            return RedirectToAction(nameof(Index));
        }

        var countries = await _countryService.GetAllCountriesAsync();
        ViewBag.CountryList = _mapper.Map<IEnumerable<VMCountry>>(countries)
            .Select(c => new SelectListItem
            {
                Value = c.IDCountry.ToString(),
                Text = c.ShortNameHr
            }).ToList();

        return View(vmCity);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var blCity = await _cityService.GetCityByIdAsync(id);
        if (blCity == null)
            return NotFound();
        var vmCity = _mapper.Map<VMCity>(blCity);
        return View(vmCity);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id, VMCity vmCity)
    {
        await _cityService.DeleteCityAsync(id);
        return RedirectToAction(nameof(Index));
    }
}