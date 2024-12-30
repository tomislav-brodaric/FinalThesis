using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalThesis.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductGroupController(ProductGroupService productGroupService) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BLProductGroup>>> GetProductGroups()
    {
        var productGroups = await productGroupService.GetAllProductGroupsAsync();
        return Ok(productGroups);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BLProductGroup>> GetProductGroup(int id)
    {
        var productGroup = await productGroupService.GetProductGroupByIdAsync(id);
        if (productGroup == null)
            return NotFound();
        return Ok(productGroup);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductGroup(BLProductGroup blProductGroup)
    {
        await productGroupService.AddProductGroupAsync(blProductGroup);
        return CreatedAtAction(nameof(CreateProductGroup), new { id = blProductGroup.IDProductGroup }, blProductGroup);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProductGroup(int id, BLProductGroup blProductGroup)
    {
        if (id != blProductGroup.IDProductGroup)
            return BadRequest();

        await productGroupService.UpdateProductGroupAsync(blProductGroup);
        var updatedProductGroup = await productGroupService.GetProductGroupByIdAsync(id);
        return Ok(updatedProductGroup);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductGroup(int id)
    {
        var productGroupToDelete = await productGroupService.GetProductGroupByIdAsync(id);
        if (productGroupToDelete == null)
            return NotFound();

        await productGroupService.DeleteProductGroupAsync(id);
        return Ok(productGroupToDelete);
    }
}
