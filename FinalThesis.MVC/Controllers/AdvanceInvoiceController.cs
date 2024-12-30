using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using FinalThesis.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class AdvanceInvoiceController : Controller
{
    private readonly AdvanceInvoiceService _advanceInvoiceService;
    private readonly PartnerService _partnerService;
    //private readonly ExemptionBasisService _exemptionBasisService;
    private readonly IMapper _mapper;

    public AdvanceInvoiceController(
        AdvanceInvoiceService advanceInvoiceService,
        PartnerService partnerService,
        //ExemptionBasisService exemptionBasisService,
        IMapper mapper)
    {
        _advanceInvoiceService = advanceInvoiceService;
        _partnerService = partnerService;
        //_exemptionBasisService = exemptionBasisService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var blAdvanceInvoices = await _advanceInvoiceService.GetAllAdvanceInvoicesAsync();
        var vmAdvanceInvoices = _mapper.Map<IEnumerable<VMAdvanceInvoice>>(blAdvanceInvoices);
        return View(vmAdvanceInvoices);
    }

    public async Task<IActionResult> Details(int id)
    {
        var blAdvanceInvoice = await _advanceInvoiceService.GetAdvanceInvoiceByIdAsync(id);
        if (blAdvanceInvoice == null)
            return NotFound();

        var vmAdvanceInvoice = _mapper.Map<VMAdvanceInvoice>(blAdvanceInvoice);
        return View(vmAdvanceInvoice);
    }

    public async Task<IActionResult> Create()
    {
        await InitializeSelectListsAsync();
        return View(new VMAdvanceInvoice());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(VMAdvanceInvoice vmAdvanceInvoice)
    {
        if (ModelState.IsValid)
        {
            var blAdvanceInvoice = _mapper.Map<BLAdvanceInvoice>(vmAdvanceInvoice);
            blAdvanceInvoice.Partner = null;
            blAdvanceInvoice.PartnerID = vmAdvanceInvoice.PartnerID;

            await _advanceInvoiceService.AddAdvanceInvoiceAsync(blAdvanceInvoice);
            return RedirectToAction(nameof(Index));
        }

        await InitializeSelectListsAsync();
        return View(vmAdvanceInvoice);
    }


    public async Task<IActionResult> Edit(int id)
    {
        var blAdvanceInvoice = await _advanceInvoiceService.GetAdvanceInvoiceByIdAsync(id);
        if (blAdvanceInvoice == null)
            return NotFound();

        await InitializeSelectListsAsync();
        var vmAdvanceInvoice = _mapper.Map<VMAdvanceInvoice>(blAdvanceInvoice);
        return View(vmAdvanceInvoice);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, VMAdvanceInvoice vmAdvanceInvoice)
    {
        if (id != vmAdvanceInvoice.IDAdvanceInvoice)
            return BadRequest();

        if (ModelState.IsValid)
        {
            // Dohvatite postojeći zapis iz baze, uključujući AdvanceInvoicePayments
            var existingInvoice = await _advanceInvoiceService.GetAdvanceInvoiceByIdAsync(id);
            if (existingInvoice == null)
            {
                return NotFound();
            }

            // Mapirajte polja iz view modela u postojeći entitet
            _mapper.Map(vmAdvanceInvoice, existingInvoice);

            // Ažurirajte ili dodajte AdvanceInvoicePayments
            existingInvoice.AdvanceInvoicePayments.Clear();
            foreach (var payment in vmAdvanceInvoice.AdvanceInvoicePayments)
            {
                var blPayment = new BLAdvanceInvoicePayment
                {
                    IDAdvanceInvoicePayment = payment.IDAdvanceInvoicePayment, // Postavite ID (ako postoji) da EF prepozna kao postojeći
                    PaymentDate = payment.PaymentDate,
                    Amount = payment.Amount,
                    AdvanceInvoiceID = existingInvoice.IDAdvanceInvoice
                };
                existingInvoice.AdvanceInvoicePayments.Add(blPayment);
            }

            await _advanceInvoiceService.UpdateAdvanceInvoiceAsync(existingInvoice);
            return RedirectToAction(nameof(Index));
        }

        await InitializeSelectListsAsync();
        return View(vmAdvanceInvoice);
    }

    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> Edit(int id, VMAdvanceInvoice vmAdvanceInvoice)
    //{
    //    if (id != vmAdvanceInvoice.IDAdvanceInvoice)
    //        return BadRequest();

    //    if (ModelState.IsValid)
    //    {
    //        var blAdvanceInvoice = _mapper.Map<BLAdvanceInvoice>(vmAdvanceInvoice);
    //        blAdvanceInvoice.Partner = null;
    //        blAdvanceInvoice.PartnerID = vmAdvanceInvoice.PartnerID;
    //        await _advanceInvoiceService.UpdateAdvanceInvoiceAsync(blAdvanceInvoice);
    //        return RedirectToAction(nameof(Index));
    //    }

    //    await InitializeSelectListsAsync();
    //    return View(vmAdvanceInvoice);
    //}

    public async Task<IActionResult> Delete(int id)
    {
        var blAdvanceInvoice = await _advanceInvoiceService.GetAdvanceInvoiceByIdAsync(id);
        if (blAdvanceInvoice == null)
            return NotFound();

        var vmAdvanceInvoice = _mapper.Map<VMAdvanceInvoice>(blAdvanceInvoice);
        return View(vmAdvanceInvoice);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _advanceInvoiceService.DeleteAdvanceInvoiceAsync(id);
        return RedirectToAction(nameof(Index));
    }

    private async Task InitializeSelectListsAsync()
    {
        var partners = await _partnerService.GetAllPartnersAsync();
        ViewBag.PartnerSelectList = new SelectList(partners.Select(p => new { p.IDPartner, p.PartnerName }), "IDPartner", "PartnerName");

        //var exemptions = await _exemptionBasisService.GetAllExemptionBasisAsync();
        //ViewBag.Exemptions = new SelectList(exemptions, "IDBasis", "BasisName");
    }
}