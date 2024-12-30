using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalThesis.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductTypeController(ProductTypeService productTypeService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BLProductType>>> GetProductTypes()
    {
        var productTypes = await productTypeService.GetAllProductTypesAsync();
        return Ok(productTypes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BLProductType>> GetProductType(int id)
    {
        var productType = await productTypeService.GetProductTypeByIdAsync(id);
        if (productType == null)
            return NotFound();
        return Ok(productType);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductType(BLProductType blProductType)
    {
        await productTypeService.AddProductTypeAsync(blProductType);
        return CreatedAtAction(nameof(CreateProductType), new { id = blProductType.IDProductType }, blProductType);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProductType(int id, BLProductType blProductType)
    {
        if (id != blProductType.IDProductType)
            return BadRequest();

        await productTypeService.UpdateProductTypeAsync(blProductType);
        var updatedProductType = await productTypeService.GetProductTypeByIdAsync(id);
        return Ok(updatedProductType);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductType(int id)
    {
        var productTypeToDelete = await productTypeService.GetProductTypeByIdAsync(id);
        if (productTypeToDelete == null)
            return NotFound();

        await productTypeService.DeleteProductTypeAsync(id);
        return Ok(productTypeToDelete);
    }
}
