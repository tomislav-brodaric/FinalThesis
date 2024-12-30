using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using FinalThesis.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalThesis.MVC.Controllers;

public class ProductGroupController(ProductGroupService productGroupService, ProductTypeService productTypeService, IMapper mapper) : Controller
{
    private readonly ProductGroupService _productGroupService = productGroupService;
    private readonly ProductTypeService _productTypeService = productTypeService;
    private readonly IMapper _mapper = mapper;

    public async Task<IActionResult> Index()
    {
        var blProductGroups = await _productGroupService.GetAllProductGroupsAsync();
        var vmProductGroups = _mapper.Map<IEnumerable<VMProductGroup>>(blProductGroups);
        return View(vmProductGroups);
    }

    public async Task<IActionResult> Details(int id)
    {
        var blProductGroup = await _productGroupService.GetProductGroupByIdAsync(id);
        if (blProductGroup == null)
            return NotFound();
        var vmProductGroup = _mapper.Map<VMProductGroup>(blProductGroup);
        return View(vmProductGroup);
    }

    public async Task<IActionResult> Create()
    {
        await InitializeProductTypeSelectListAsync();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(VMProductGroup vmProductGroup)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var blProductGroup = _mapper.Map<BLProductGroup>(vmProductGroup);
                await _productGroupService.AddProductGroupAsync(blProductGroup);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
        }

        await InitializeProductTypeSelectListAsync();
        return View(vmProductGroup);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var blProductGroup = await _productGroupService.GetProductGroupByIdAsync(id);
        if (blProductGroup == null)
            return NotFound();
        var vmProductGroup = _mapper.Map<VMProductGroup>(blProductGroup);

        await InitializeProductTypeSelectListAsync();
        return View(vmProductGroup);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, VMProductGroup vmProductGroup)
    {
        if (id != vmProductGroup.IDProductGroup)
            return BadRequest();

        if (ModelState.IsValid)
        {
            var blProductGroup = _mapper.Map<BLProductGroup>(vmProductGroup);
            await _productGroupService.UpdateProductGroupAsync(blProductGroup);
            return RedirectToAction(nameof(Index));
        }

        await InitializeProductTypeSelectListAsync();
        return View(vmProductGroup);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var blProductGroup = await _productGroupService.GetProductGroupByIdAsync(id);
        if (blProductGroup == null)
            return NotFound();
        var vmProductGroup = _mapper.Map<VMProductGroup>(blProductGroup);
        return View(vmProductGroup);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id, VMProductGroup vmProductGroup)
    {
        await _productGroupService.DeleteProductGroupAsync(id);
        return RedirectToAction(nameof(Index));
    }

    private async Task InitializeProductTypeSelectListAsync()
    {
        var productTypes = await _productTypeService.GetAllProductTypesAsync();
        ViewBag.ProductTypeList = new SelectList(productTypes, "IDProductType", "TypeName");
    }
}
