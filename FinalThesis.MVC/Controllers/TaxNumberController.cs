using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using FinalThesis.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace FinalThesis.MVC.Controllers;

public class TaxNumberController(TaxNumberService taxNumberService, TaxRateService taxRateService, IMapper mapper) : Controller
{
    private readonly TaxNumberService _taxNumberService = taxNumberService;
    private readonly TaxRateService _taxRateService = taxRateService;
    private readonly IMapper _mapper = mapper;

    public async Task<IActionResult> Index()
    {
        var blTaxNumbers = await _taxNumberService.GetAllTaxNumbersAsync();
        var vmTaxNumbers = _mapper.Map<IEnumerable<VMTaxNumber>>(blTaxNumbers);
        return View(vmTaxNumbers);
    }

    public async Task<IActionResult> Details(int id)
    {
        var blTaxNumber = await _taxNumberService.GetTaxNumberByIdAsync(id);
        if (blTaxNumber == null)
            return NotFound();

        var vmTaxNumber = _mapper.Map<VMTaxNumber>(blTaxNumber);
        return View(vmTaxNumber);
    }

    public async Task<IActionResult> Create()
    {
        var taxRates = await _taxRateService.GetAllTaxRatesAsync();
        ViewBag.TaxRateList = _mapper.Map<IEnumerable<VMTaxRate>>(taxRates)
            .Select(tr => new SelectListItem
            {
                Value = tr.IDTaxRate.ToString(),
                Text = tr.TaxRateName
            }).ToList();

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(VMTaxNumber vmTaxNumber)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var blTaxNumber = _mapper.Map<BLTaxNumber>(vmTaxNumber);
                await _taxNumberService.AddTaxNumberAsync(blTaxNumber);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
        }

        var taxRates = await _taxRateService.GetAllTaxRatesAsync();
        ViewBag.TaxRateList = _mapper.Map<IEnumerable<VMTaxRate>>(taxRates)
            .Select(tr => new SelectListItem
            {
                Value = tr.IDTaxRate.ToString(),
                Text = tr.TaxRateName
            }).ToList();

        return View(vmTaxNumber);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var blTaxNumber = await _taxNumberService.GetTaxNumberByIdAsync(id);
        if (blTaxNumber == null)
            return NotFound();

        var vmTaxNumber = _mapper.Map<VMTaxNumber>(blTaxNumber);

        var taxRates = await _taxRateService.GetAllTaxRatesAsync();
        ViewBag.TaxRateList = _mapper.Map<IEnumerable<VMTaxRate>>(taxRates)
            .Select(tr => new SelectListItem
            {
                Value = tr.IDTaxRate.ToString(),
                Text = tr.TaxRateName,
                Selected = (tr.IDTaxRate == vmTaxNumber.TaxRateID)
            }).ToList();

        return View(vmTaxNumber);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, VMTaxNumber vmTaxNumber)
    {
        if (id != vmTaxNumber.IDTaxNumber)
            return BadRequest();

        if (ModelState.IsValid)
        {
            var blTaxNumber = _mapper.Map<BLTaxNumber>(vmTaxNumber);
            await _taxNumberService.UpdateTaxNumberAsync(blTaxNumber);
            return RedirectToAction(nameof(Index));
        }

        var taxRates = await _taxRateService.GetAllTaxRatesAsync();
        ViewBag.TaxRateList = _mapper.Map<IEnumerable<VMTaxRate>>(taxRates)
            .Select(tr => new SelectListItem
            {
                Value = tr.IDTaxRate.ToString(),
                Text = tr.TaxRateName
            }).ToList();

        return View(vmTaxNumber);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var blTaxNumber = await _taxNumberService.GetTaxNumberByIdAsync(id);
        if (blTaxNumber == null)
            return NotFound();

        var vmTaxNumber = _mapper.Map<VMTaxNumber>(blTaxNumber);
        return View(vmTaxNumber);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id, VMTaxNumber vmTaxNumber)
    {
        await _taxNumberService.DeleteTaxNumberAsync(id);
        return RedirectToAction(nameof(Index));
    }
}