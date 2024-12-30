//using AutoMapper;
//using FinalThesis.API.BLModels;
//using FinalThesis.API.Services;
//using FinalThesis.MVC.ViewModels;
//using Microsoft.AspNetCore.Mvc;

//namespace FinalThesis.MVC.Controllers;

//public class ExemptionBasisController(ExemptionBasisService exemptionBasisService, IMapper mapper) : Controller
//{
//    private readonly ExemptionBasisService _exemptionBasisService = exemptionBasisService;
//    private readonly IMapper _mapper = mapper;

//    public async Task<IActionResult> Index()
//    {
//        var blExemptionBases = await _exemptionBasisService.GetAllExemptionBasisAsync();
//        var vmExemptionBases = _mapper.Map<IEnumerable<VMExemptionBasis>>(blExemptionBases);
//        return View(vmExemptionBases);
//    }

//    public async Task<IActionResult> Details(int id)
//    {
//        var blExemptionBasis = await _exemptionBasisService.GetExemptionBasisByIdAsync(id);
//        if (blExemptionBasis == null)
//            return NotFound();

//        var vmExemptionBasis = _mapper.Map<VMExemptionBasis>(blExemptionBasis);
//        return View(vmExemptionBasis);
//    }

//    public IActionResult Create()
//    {
//        return View();
//    }

//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public async Task<IActionResult> Create(VMExemptionBasis vmExemptionBasis)
//    {
//        if (ModelState.IsValid)
//        {
//            try
//            {
//                var blExemptionBasis = _mapper.Map<BLExemptionBasis>(vmExemptionBasis);
//                await _exemptionBasisService.AddExemptionBasisAsync(blExemptionBasis);
//                return RedirectToAction(nameof(Index));
//            }
//            catch (InvalidOperationException ex)
//            {
//                ModelState.AddModelError(string.Empty, ex.Message);
//            }
//        }
//        return View(vmExemptionBasis);
//    }

//    public async Task<IActionResult> Edit(int id)
//    {
//        var blExemptionBasis = await _exemptionBasisService.GetExemptionBasisByIdAsync(id);
//        if (blExemptionBasis == null)
//            return NotFound();

//        var vmExemptionBasis = _mapper.Map<VMExemptionBasis>(blExemptionBasis);
//        return View(vmExemptionBasis);
//    }

//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public async Task<IActionResult> Edit(int id, VMExemptionBasis vmExemptionBasis)
//    {
//        if (id != vmExemptionBasis.IDBasis)
//            return BadRequest();

//        if (ModelState.IsValid)
//        {
//            var blExemptionBasis = _mapper.Map<BLExemptionBasis>(vmExemptionBasis);
//            await _exemptionBasisService.UpdateExemptionBasisAsync(blExemptionBasis);
//            return RedirectToAction(nameof(Index));
//        }
//        return View(vmExemptionBasis);
//    }

//    public async Task<IActionResult> Delete(int id)
//    {
//        var blExemptionBasis = await _exemptionBasisService.GetExemptionBasisByIdAsync(id);
//        if (blExemptionBasis == null)
//            return NotFound();

//        var vmExemptionBasis = _mapper.Map<VMExemptionBasis>(blExemptionBasis);
//        return View(vmExemptionBasis);
//    }

//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public async Task<IActionResult> Delete(int id, VMExemptionBasis vmExemptionBasis)
//    {
//        await _exemptionBasisService.DeleteExemptionBasisAsync(id);
//        return RedirectToAction(nameof(Index));
//    }
//}