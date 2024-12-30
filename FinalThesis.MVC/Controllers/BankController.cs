using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using FinalThesis.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalThesis.MVC.Controllers;

public class BankController(BankService bankService, IMapper mapper) : Controller
{
    private readonly BankService _bankService = bankService;
    private readonly IMapper _mapper = mapper;

    public async Task<IActionResult> Index()
    {
        var blBanks = await _bankService.GetAllBanksAsync();
        var vmBanks = _mapper.Map<IEnumerable<VMBank>>(blBanks);
        return View(vmBanks);
    }

    public async Task<IActionResult> Details(int id)
    {
        var blBank = await _bankService.GetBankByIdAsync(id);
        if (blBank == null)
            return NotFound();
        var vmBank = _mapper.Map<VMBank>(blBank);
        return View(vmBank);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(VMBank vmBank)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var blBank = _mapper.Map<BLBank>(vmBank);
                await _bankService.AddBankAsync(blBank);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
        }
        return View(vmBank);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var blBank = await _bankService.GetBankByIdAsync(id);
        if (blBank == null)
            return NotFound();
        var vmBank = _mapper.Map<VMBank>(blBank);
        return View(vmBank);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, VMBank vmBank)
    {
        if (id != vmBank.IDBank)
            return BadRequest();

        if (ModelState.IsValid)
        {
            var blBank = _mapper.Map<BLBank>(vmBank);
            await _bankService.UpdateBankAsync(blBank);
            return RedirectToAction(nameof(Index));
        }
        return View(vmBank);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var blBank = await _bankService.GetBankByIdAsync(id);
        if (blBank == null)
            return NotFound();
        var vmBank = _mapper.Map<VMBank>(blBank);
        return View(vmBank);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id, VMBank vmBank)
    {
        await _bankService.DeleteBankAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
