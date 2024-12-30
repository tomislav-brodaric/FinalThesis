//using FinalThesis.API.BLModels;
//using FinalThesis.API.Services;
//using Microsoft.AspNetCore.Mvc;

//namespace FinalThesis.API.Controllers;

//[Route("api/[controller]")]
//[ApiController]
//public class ExemptionBasisController(ExemptionBasisService exemptionBasisService) : ControllerBase
//{
//    private readonly ExemptionBasisService _exemptionBasisService = exemptionBasisService;

//    [HttpGet]
//    public async Task<ActionResult<IEnumerable<BLExemptionBasis>>> GetPDVExemptions()
//    {
//        var pdvExemptions = await _exemptionBasisService.GetAllExemptionBasisAsync();
//        return Ok(pdvExemptions);
//    }

//    [HttpGet("{id}")]
//    public async Task<ActionResult<BLExemptionBasis>> GetPDVExemption(int id)
//    {
//        var pdvExemption = await _exemptionBasisService.GetExemptionBasisByIdAsync(id);
//        if (pdvExemption == null)
//            return NotFound();
//        return Ok(pdvExemption);
//    }

//    [HttpPost]
//    public async Task<IActionResult> CreateExemptionBasis(BLExemptionBasis blExemptionBasis)
//    {
//        await _exemptionBasisService.AddExemptionBasisAsync(blExemptionBasis);
//        return CreatedAtAction(nameof(CreateExemptionBasis), new { id = blExemptionBasis.IDBasis }, blExemptionBasis);
//    }

//    [HttpPut("{id}")]
//    public async Task<IActionResult> UpdateExemptionBasis(int id, BLExemptionBasis blExemptionBasis)
//    {
//        if (id != blExemptionBasis.IDBasis)
//            return BadRequest();
//        await _exemptionBasisService.UpdateExemptionBasisAsync(blExemptionBasis);
//        var updatedExemptionBasis = await _exemptionBasisService.GetExemptionBasisByIdAsync(id);
//        return Ok(updatedExemptionBasis);
//    }

//    [HttpDelete("{id}")]
//    public async Task<IActionResult> DeleteExemptionBasis(int id)
//    {
//        var exemptionBasisToDelete = await _exemptionBasisService.GetExemptionBasisByIdAsync(id);
//        if (exemptionBasisToDelete == null)
//            return NotFound();
//        await _exemptionBasisService.DeleteExemptionBasisAsync(id);
//        return Ok(exemptionBasisToDelete);
//    }
//}
