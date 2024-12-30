using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using FinalThesis.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalThesis.MVC.Controllers
{
    public class TaxRateController(TaxRateService taxRateService, IMapper mapper) : Controller
    {
        private readonly TaxRateService _taxRateService = taxRateService;
        private readonly IMapper _mapper = mapper;

        public async Task<IActionResult> Index()
        {
            var blTaxRates = await _taxRateService.GetAllTaxRatesAsync();
            var vmTaxRates = _mapper.Map<IEnumerable<VMTaxRate>>(blTaxRates);
            return View(vmTaxRates);
        }

        public async Task<IActionResult> Details(int id)
        {
            var blTaxRate = await _taxRateService.GetTaxRateByIdAsync(id);
            if (blTaxRate == null)
                return NotFound();

            var vmTaxRate = _mapper.Map<VMTaxRate>(blTaxRate);
            return View(vmTaxRate);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VMTaxRate vmTaxRate)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var blTaxRate = _mapper.Map<BLTaxRate>(vmTaxRate);
                    await _taxRateService.AddTaxRateAsync(blTaxRate);
                    return RedirectToAction(nameof(Index));
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(vmTaxRate);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var blTaxRate = await _taxRateService.GetTaxRateByIdAsync(id);
            if (blTaxRate == null)
                return NotFound();

            var vmTaxRate = _mapper.Map<VMTaxRate>(blTaxRate);
            return View(vmTaxRate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, VMTaxRate vmTaxRate)
        {
            if (id != vmTaxRate.IDTaxRate)
                return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    var blTaxRate = _mapper.Map<BLTaxRate>(vmTaxRate);
                    await _taxRateService.UpdateTaxRateAsync(blTaxRate);
                    return RedirectToAction(nameof(Index));
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(vmTaxRate);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var blTaxRate = await _taxRateService.GetTaxRateByIdAsync(id);
            if (blTaxRate == null)
                return NotFound();

            var vmTaxRate = _mapper.Map<VMTaxRate>(blTaxRate);
            return View(vmTaxRate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, VMTaxRate vmTaxRate)
        {
            await _taxRateService.DeleteTaxRateAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
