using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalThesis.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(ProductService productService) : ControllerBase
{
    private readonly ProductService _productService = productService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BLProduct>>> GetProducts()
    {
        var products = await _productService.GetAllProductsAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BLProduct>> GetProduct(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null)
            return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(BLProduct blProduct)
    {
        await _productService.AddProductAsync(blProduct);
        return CreatedAtAction(nameof(CreateProduct), new { id = blProduct.IDProduct }, blProduct);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, BLProduct blProduct)
    {
        if (id != blProduct.IDProduct)
            return BadRequest();

        await _productService.UpdateProductAsync(blProduct);
        var updatedProduct = await _productService.GetProductByIdAsync(id);
        return Ok(updatedProduct);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var productToDelete = await _productService.GetProductByIdAsync(id);
        if (productToDelete == null)
            return NotFound();

        await _productService.DeleteProductAsync(id);
        return Ok(productToDelete);
    }
}
