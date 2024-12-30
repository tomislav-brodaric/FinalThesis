using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using FinalThesis.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalThesis.MVC.Controllers;

public class ProductController(ProductService productService, ProductGroupService productGroupService, TaxNumberService taxNumberService, IMapper mapper) : Controller
{
    private readonly ProductService _productService = productService;
    private readonly ProductGroupService _productGroupService = productGroupService;
    private readonly TaxNumberService _taxNumberService = taxNumberService;
    private readonly IMapper _mapper = mapper;

    public async Task<IActionResult> Index()
    {
        var blProducts = await _productService.GetAllProductsAsync();
        var vmProducts = _mapper.Map<IEnumerable<VMProduct>>(blProducts);
        return View(vmProducts);
    }

    public async Task<IActionResult> Details(int id)
    {
        var blProduct = await _productService.GetProductByIdAsync(id);
        if (blProduct == null)
            return NotFound();
        var vmProduct = _mapper.Map<VMProduct>(blProduct);
        return View(vmProduct);
    }

    public async Task<IActionResult> Create()
    {
        await InitializeSelectListsAsync();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(VMProduct vmProduct)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var blProduct = _mapper.Map<BLProduct>(vmProduct);
                await _productService.AddProductAsync(blProduct);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
        }
        await InitializeSelectListsAsync();
        return View(vmProduct);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var blProduct = await _productService.GetProductByIdAsync(id);
        if (blProduct == null)
            return NotFound();
        var vmProduct = _mapper.Map<VMProduct>(blProduct);

        await InitializeSelectListsAsync();
        return View(vmProduct);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, VMProduct vmProduct)
    {
        if (id != vmProduct.IDProduct)
            return BadRequest();

        if (ModelState.IsValid)
        {
            var blProduct = _mapper.Map<BLProduct>(vmProduct);
            await _productService.UpdateProductAsync(blProduct);
            return RedirectToAction(nameof(Index));
        }

        await InitializeSelectListsAsync();
        return View(vmProduct);
    }

    private async Task InitializeSelectListsAsync()
    {
        var productGroups = await _productGroupService.GetAllProductGroupsAsync();
        ViewBag.ProductGroupList = new SelectList(productGroups, "IDProductGroup", "GroupName");

        var taxNumbers = await _taxNumberService.GetAllTaxNumbersAsync();
        ViewBag.TaxNumberList = new SelectList(taxNumbers, "IDTaxNumber", "TaxCode");
    }
}
