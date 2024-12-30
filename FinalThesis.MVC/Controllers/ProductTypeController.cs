using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using FinalThesis.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalThesis.MVC.Controllers;

public class ProductTypeController(ProductTypeService productTypeService, IMapper mapper) : Controller
{
    private readonly ProductTypeService _productTypeService = productTypeService;
    private readonly IMapper _mapper = mapper;

    public async Task<IActionResult> Index()
    {
        var blProductTypes = await _productTypeService.GetAllProductTypesAsync();
        var vmProductTypes = _mapper.Map<IEnumerable<VMProductType>>(blProductTypes);
        return View(vmProductTypes);
    }

    public async Task<IActionResult> Details(int id)
    {
        var blProductType = await _productTypeService.GetProductTypeByIdAsync(id);
        if (blProductType == null)
            return NotFound();
        var vmProductType = _mapper.Map<VMProductType>(blProductType);
        return View(vmProductType);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(VMProductType vmProductType)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var blProductType = _mapper.Map<BLProductType>(vmProductType);
                await _productTypeService.AddProductTypeAsync(blProductType);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
        }
        return View(vmProductType);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var blProductType = await _productTypeService.GetProductTypeByIdAsync(id);
        if (blProductType == null)
            return NotFound();
        var vmProductType = _mapper.Map<VMProductType>(blProductType);
        return View(vmProductType);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, VMProductType vmProductType)
    {
        if (id != vmProductType.IDProductType)
            return BadRequest();

        if (ModelState.IsValid)
        {
            var blProductType = _mapper.Map<BLProductType>(vmProductType);
            await _productTypeService.UpdateProductTypeAsync(blProductType);
            return RedirectToAction(nameof(Index));
        }
        return View(vmProductType);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var blProductType = await _productTypeService.GetProductTypeByIdAsync(id);
        if (blProductType == null)
            return NotFound();
        var vmProductType = _mapper.Map<VMProductType>(blProductType);
        return View(vmProductType);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id, VMProductType vmProductType)
    {
        await _productTypeService.DeleteProductTypeAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
