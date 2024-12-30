using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using FinalThesis.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalThesis.MVC.Controllers;

public class CurrencyController(CurrencyService currencyService, IMapper mapper) : Controller
{
    private readonly CurrencyService _currencyService = currencyService;
    private readonly IMapper _mapper = mapper;

    public async Task<IActionResult> Index()
    {
        var blCurrencies = await _currencyService.GetAllCurrenciesAsync();
        var vmCurrencies = _mapper.Map<IEnumerable<VMCurrency>>(blCurrencies);
        return View(vmCurrencies);
    }

    public async Task<IActionResult> Details(int id)
    {
        var blCurrency = await _currencyService.GetCurrencyByIdAsync(id);
        if (blCurrency == null) 
            return NotFound();

        var vmCurrency = _mapper.Map<VMCurrency>(blCurrency);
        return View(vmCurrency);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(VMCurrency vmCurrency)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var blCurrency = _mapper.Map<BLCurrency>(vmCurrency);
                await _currencyService.AddCurrencyAsync(blCurrency);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
        }
        return View(vmCurrency);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var blCurrency = await _currencyService.GetCurrencyByIdAsync(id);
        if (blCurrency == null) 
            return NotFound();
        var vmCurrency = _mapper.Map<VMCurrency>(blCurrency);
        return View(vmCurrency);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, VMCurrency vmCurrency)
    {
        if (id != vmCurrency.IDCurrency) 
            return BadRequest();

        if (ModelState.IsValid)
        {
            var blCurrency = _mapper.Map<BLCurrency>(vmCurrency);
            await _currencyService.UpdateCurrencyAsync(blCurrency);
            return RedirectToAction(nameof(Index));
        }
        return View(vmCurrency);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var blCurrency = await _currencyService.GetCurrencyByIdAsync(id);
        if (blCurrency == null) 
            return NotFound();
        var vmCurrency = _mapper.Map<VMCurrency>(blCurrency);
        return View(vmCurrency);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id, VMCurrency vmCurrency)
    {
        await _currencyService.DeleteCurrencyAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
