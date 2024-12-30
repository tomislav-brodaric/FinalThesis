using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using FinalThesis.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class InvoiceController : Controller
{
    private readonly InvoiceService _invoiceService;
    private readonly PartnerService _partnerService;
    private readonly ProductService _productService;
    private readonly InvoiceProductService _invoiceProductService;
    private readonly IMapper _mapper;

    public InvoiceController(InvoiceService invoiceService, PartnerService partnerService, ProductService productService, InvoiceProductService invoiceProductService, IMapper mapper)
    {
        _invoiceService = invoiceService;
        _partnerService = partnerService;
        _productService = productService;
        _invoiceProductService = invoiceProductService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var blInvoices = await _invoiceService.GetAllInvoicesAsync();
        var vmInvoices = _mapper.Map<IEnumerable<VMInvoice>>(blInvoices);
        return View(vmInvoices);
    }

    public async Task<IActionResult> Details(int id)
    {
        var blInvoice = await _invoiceService.GetInvoiceByIdAsync(id);
        if (blInvoice == null)
            return NotFound();

        var vmInvoice = _mapper.Map<VMInvoice>(blInvoice);
        return View(vmInvoice);
    }

    public async Task<IActionResult> Create()
    {
        await InitializeSelectListsAsync();
        return View(new VMInvoice());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(VMInvoice vmInvoice)
    {
        if (ModelState.IsValid)
        {
            var blInvoice = _mapper.Map<BLInvoice>(vmInvoice);
            blInvoice.InvoiceAmount = vmInvoice.InvoiceProducts.Sum(p => p.Quantity * p.Price * (1 - (p.Discount ?? 0) / 100));

            await _invoiceService.AddInvoiceAsync(blInvoice);
            return RedirectToAction(nameof(Index));
        }

        await InitializeSelectListsAsync();
        return View(vmInvoice);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var blInvoice = await _invoiceService.GetInvoiceByIdAsync(id);
        if (blInvoice == null)
            return NotFound();

        await InitializeSelectListsAsync();
        var vmInvoice = _mapper.Map<VMInvoice>(blInvoice);
        return View(vmInvoice);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, VMInvoice vmInvoice)
    {
        if (id != vmInvoice.IDInvoice)
            return BadRequest();

        if (ModelState.IsValid)
        {
            try
            {
                var existingInvoice = await _invoiceService.GetInvoiceByIdAsync(id);
                if (existingInvoice == null) 
                    return NotFound();

                var updatedInvoice = _mapper.Map<BLInvoice>(vmInvoice);

                var removedProducts = existingInvoice.InvoiceProducts
                    .Where(p => !vmInvoice.InvoiceProducts.Any(vp => vp.IDInvoiceProduct == p.IDInvoiceProduct))
                    .ToList();

                foreach (var removedProduct in removedProducts)
                {
                    await _invoiceProductService.DeleteInvoiceProductAsync(removedProduct.IDInvoiceProduct);
                }

                foreach (var product in vmInvoice.InvoiceProducts)
                {
                    if (product.IDInvoiceProduct == null || product.IDInvoiceProduct == 0) 
                    {
                        var newProduct = _mapper.Map<BLInvoiceProduct>(product);
                        newProduct.InvoiceID = updatedInvoice.IDInvoice;
                        await _invoiceProductService.AddInvoiceProductAsync(newProduct);
                    }
                    else
                    {
                        var existingProduct = await _invoiceProductService.GetInvoiceProductByIdAsync(product.IDInvoiceProduct.Value);
                        if (existingProduct != null)
                        {
                            _mapper.Map(product, existingProduct);
                            await _invoiceProductService.UpdateInvoiceProductAsync(existingProduct);
                        }
                    }
                }

                updatedInvoice.InvoiceAmount = vmInvoice.InvoiceProducts
                    .Sum(p => p.Quantity * p.Price * (1 - (p.Discount ?? 0) / 100));

                await _invoiceService.UpdateInvoiceAsync(updatedInvoice);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error while updating the invoice: {ex.Message}");
            }
        }

        await InitializeSelectListsAsync();
        return View(vmInvoice);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var blInvoice = await _invoiceService.GetInvoiceByIdAsync(id);
        if (blInvoice == null)
            return NotFound();

        var vmInvoice = _mapper.Map<VMInvoice>(blInvoice);
        return View(vmInvoice);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _invoiceService.DeleteInvoiceAsync(id);
        return RedirectToAction(nameof(Index));
    }

    private async Task InitializeSelectListsAsync()
    {
        var partners = await _partnerService.GetAllPartnersAsync();
        ViewBag.PartnerSelectList = new SelectList(partners.Select(p => new { p.IDPartner, p.PartnerName }), "IDPartner", "PartnerName");

        var products = await _productService.GetAllProductsAsync();
        ViewBag.ProductSelectList = new SelectList(products.Select(p => new { p.IDProduct, p.ProductName }), "IDProduct", "ProductName");
    }
}
