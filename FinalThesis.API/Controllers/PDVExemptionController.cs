//using FinalThesis.API.BLModels;
//using FinalThesis.API.Services;
//using Microsoft.AspNetCore.Mvc;

//namespace FinalThesis.API.Controllers;

//[Route("api/[controller]")]
//[ApiController]
//public class PDVExemptionController(PDVExemptionService pdvExemptionService) : ControllerBase
//{
//    private readonly PDVExemptionService _pdvExemptionService = pdvExemptionService;

//    [HttpGet]
//    public async Task<ActionResult<IEnumerable<BLPDVExemption>>> GetPDVExemptions()
//    {
//        var pdvExemptions = await _pdvExemptionService.GetAllPDVExemptionsAsync();
//        return Ok(pdvExemptions);
//    }

//    [HttpGet("{id}")]
//    public async Task<ActionResult<BLPDVExemption>> GetPDVExemption(int id)
//    {
//        var pdvExemption = await _pdvExemptionService.GetPDVExemptionByIdAsync(id);
//        if (pdvExemption == null)
//            return NotFound();
//        return Ok(pdvExemption);
//    }

//    [HttpPost]
//    public async Task<IActionResult> CreatePDVExemption(BLPDVExemption blPDVExemption)
//    {
//        await _pdvExemptionService.AddPDVExemptionAsync(blPDVExemption);
//        return CreatedAtAction(nameof(CreatePDVExemption), new { id = blPDVExemption.IDExemption }, blPDVExemption);
//    }

//    [HttpPut("{id}")]
//    public async Task<IActionResult> UpdatePDVExemption(int id, BLPDVExemption blPDVExemption)
//    {
//        if (id != blPDVExemption.IDExemption)
//            return BadRequest();
//        await _pdvExemptionService.UpdatePDVExemptionAsync(blPDVExemption);
//        var updatedPDVExemption = await _pdvExemptionService.GetPDVExemptionByIdAsync(id);
//        return Ok(updatedPDVExemption);
//    }

//    [HttpDelete("{id}")]
//    public async Task<IActionResult> DeletePDVExemption(int id)
//    {
//        var pdvExemptionToDelete = await _pdvExemptionService.GetPDVExemptionByIdAsync(id);
//        if (pdvExemptionToDelete == null)
//            return NotFound();
//        await _pdvExemptionService.DeletePDVExemptionAsync(id);
//        return Ok(pdvExemptionToDelete);
//    }
//}