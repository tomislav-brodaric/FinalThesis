using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using FinalThesis.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalThesis.MVC.Controllers;

public class GiroAccountController(GiroAccountService giroAccountService, BankService bankService, IMapper mapper) : Controller
{
    public async Task<IActionResult> Index()
    {
        var blGiroAccounts = await giroAccountService.GetAllGiroAccountsAsync();
        var vmGiroAccounts = mapper.Map<IEnumerable<VMGiroAccount>>(blGiroAccounts);
        return View(vmGiroAccounts);
    }

    public async Task<IActionResult> Details(int id)
    {
        var blGiroAccount = await giroAccountService.GetGiroAccountByIdAsync(id);
        if (blGiroAccount == null)
            return NotFound();
        var vmGiroAccount = mapper.Map<VMGiroAccount>(blGiroAccount);
        return View(vmGiroAccount);
    }

    public async Task<IActionResult> Create(int? IDBank = null)
    {
        await PopulateBanksDropDownList(IDBank);
        var referer = Request.Headers["Referer"].ToString();
        var vmGiroAccount = new VMGiroAccount
        {
            ReturnUrl = !string.IsNullOrEmpty(referer) ? referer : Url.Action("Index", "GiroAccount")
        };

        return View(vmGiroAccount);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(VMGiroAccount vmGiroAccount)
    {
        if (!ModelState.IsValid)
        {
            LogModelStateErrors();
            await PopulateBanksDropDownList(vmGiroAccount.IDBank);
            return View(vmGiroAccount);
        }

        try
        {
            var blGiroAccount = mapper.Map<BLGiroAccount>(vmGiroAccount);
            await giroAccountService.AddGiroAccountAsync(blGiroAccount);
            return Redirect(vmGiroAccount.ReturnUrl ?? Url.Action("Index"));
        }
        catch (InvalidOperationException ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
        }

        await PopulateBanksDropDownList(vmGiroAccount.IDBank);
        return View(vmGiroAccount);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var blGiroAccount = await giroAccountService.GetGiroAccountByIdAsync(id);
        if (blGiroAccount == null)
            return NotFound();

        var vmGiroAccount = mapper.Map<VMGiroAccount>(blGiroAccount);
        await PopulateBanksDropDownList(vmGiroAccount.IDBank);
        return View(vmGiroAccount);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, VMGiroAccount vmGiroAccount)
    {
        if (id != vmGiroAccount.IDGiroAccount)
            return BadRequest();

        if (!ModelState.IsValid)
        {
            await PopulateBanksDropDownList(vmGiroAccount.IDBank);
            return View(vmGiroAccount);
        }

        try
        {
            var blGiroAccount = mapper.Map<BLGiroAccount>(vmGiroAccount);
            await giroAccountService.UpdateGiroAccountAsync(blGiroAccount);
            return RedirectToAction(nameof(Index));
        }
        catch (InvalidOperationException ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
        }

        await PopulateBanksDropDownList(vmGiroAccount.IDBank);
        return View(vmGiroAccount);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id, VMGiroAccount vmGiroAccount)
    {
        await giroAccountService.DeleteGiroAccountAsync(id);
        return RedirectToAction(nameof(Index));
    }

    private async Task PopulateBanksDropDownList(int? selectedBankId = null)
    {
        var banks = await bankService.GetAllBanksAsync();
        ViewBag.Banks = mapper.Map<IEnumerable<VMBank>>(banks)
            .Select(b => new SelectListItem
            {
                Value = b.IDBank.ToString(),
                Text = b.BankName,
                Selected = (b.IDBank == selectedBankId)
            }).ToList();
    }

    private void LogModelStateErrors()
    {
        var errorMessages = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
        foreach (var error in errorMessages)
        {
            Console.WriteLine(error);
        }
    }
}
