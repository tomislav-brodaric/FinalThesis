//using AutoMapper;
//using FinalThesis.API.BLModels;
//using FinalThesis.API.Services;
//using FinalThesis.MVC.ViewModels;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;

//namespace FinalThesis.MVC.Controllers;

//public class PDVExemptionController(PDVExemptionService pdvExemptionService, ExemptionBasisService exemptionBasisService, IMapper mapper) : Controller
//{

//    private readonly PDVExemptionService _pdvExemptionService = pdvExemptionService;
//    private readonly ExemptionBasisService _exemptionBasisService = exemptionBasisService;
//    private readonly IMapper _mapper = mapper;

//    public async Task<IActionResult> Index()
//    {
//        var blExemptions = await _pdvExemptionService.GetAllPDVExemptionsAsync();
//        var vmExemptions = _mapper.Map<IEnumerable<VMPDVExemption>>(blExemptions);
//        return View(vmExemptions);
//    }

//    public async Task<IActionResult> Details(int id)
//    {
//        var blExemption = await _pdvExemptionService.GetPDVExemptionByIdAsync(id);
//        if (blExemption == null)
//            return NotFound();

//        var vmExemption = _mapper.Map<VMPDVExemption>(blExemption);
//        return View(vmExemption);
//    }

//    public async Task<IActionResult> Create()
//    {
//        var basisList = await _exemptionBasisService.GetAllExemptionBasisAsync();
//        ViewBag.BasisList = _mapper.Map<IEnumerable<VMExemptionBasis>>(basisList)
//            .Select(b => new SelectListItem
//            {
//                Value = b.IDBasis.ToString(),
//                Text = b.BasisName
//            }).ToList();

//        return View();
//    }

//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public async Task<IActionResult> Create(VMPDVExemption vmExemption)
//    {
//        if (ModelState.IsValid)
//        {
//            try
//            {
//                var blExemption = _mapper.Map<BLPDVExemption>(vmExemption);
//                await _pdvExemptionService.AddPDVExemptionAsync(blExemption);
//                return RedirectToAction(nameof(Index));
//            }
//            catch (InvalidOperationException ex)
//            {
//                ModelState.AddModelError(string.Empty, ex.Message);
//            }
//        }

//        var basisList = await _exemptionBasisService.GetAllExemptionBasisAsync();
//        ViewBag.BasisList = _mapper.Map<IEnumerable<VMExemptionBasis>>(basisList)
//            .Select(b => new SelectListItem
//            {
//                Value = b.IDBasis.ToString(),
//                Text = b.BasisName
//            }).ToList();

//        return View(vmExemption);
//    }

//    public async Task<IActionResult> Edit(int id)
//    {
//        var blExemption = await _pdvExemptionService.GetPDVExemptionByIdAsync(id);
//        if (blExemption == null)
//            return NotFound();

//        var vmExemption = _mapper.Map<VMPDVExemption>(blExemption);

//        var basisList = await _exemptionBasisService.GetAllExemptionBasisAsync();
//        ViewBag.BasisList = _mapper.Map<IEnumerable<VMExemptionBasis>>(basisList)
//            .Select(b => new SelectListItem
//            {
//                Value = b.IDBasis.ToString(),
//                Text = b.BasisName,
//                Selected = (b.IDBasis == vmExemption.BasisID)
//            }).ToList();

//        return View(vmExemption);
//    }

//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public async Task<IActionResult> Edit(int id, VMPDVExemption vmExemption)
//    {
//        if (id != vmExemption.IDExemption)
//            return BadRequest();

//        if (ModelState.IsValid)
//        {
//            var blExemption = _mapper.Map<BLPDVExemption>(vmExemption);
//            await _pdvExemptionService.UpdatePDVExemptionAsync(blExemption);
//            return RedirectToAction(nameof(Index));
//        }

//        var basisList = await _exemptionBasisService.GetAllExemptionBasisAsync();
//        ViewBag.BasisList = _mapper.Map<IEnumerable<VMExemptionBasis>>(basisList)
//            .Select(b => new SelectListItem
//            {
//                Value = b.IDBasis.ToString(),
//                Text = b.BasisName
//            }).ToList();

//        return View(vmExemption);
//    }

//    public async Task<IActionResult> Delete(int id)
//    {
//        var blExemption = await _pdvExemptionService.GetPDVExemptionByIdAsync(id);
//        if (blExemption == null)
//            return NotFound();

//        var vmExemption = _mapper.Map<VMPDVExemption>(blExemption);
//        return View(vmExemption);
//    }

//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public async Task<IActionResult> Delete(int id, VMPDVExemption vmExemption)
//    {
//        await _pdvExemptionService.DeletePDVExemptionAsync(id);
//        return RedirectToAction(nameof(Index));
//    }
//}