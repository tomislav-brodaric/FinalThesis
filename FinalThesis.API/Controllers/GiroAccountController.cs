using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalThesis.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiroAccountController(GiroAccountService giroAccountService) : Controller
    {
        private readonly GiroAccountService _giroAccountService = giroAccountService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BLGiroAccount>>> GetGiroAccounts()
        {
            var giroAccounts = await _giroAccountService.GetAllGiroAccountsAsync();
            return Ok(giroAccounts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BLGiroAccount>> GetGiroAccount(int id)
        {
            var giroAccount = await _giroAccountService.GetGiroAccountByIdAsync(id);
            if (giroAccount == null)
            {
                return NotFound();
            }
            return Ok(giroAccount);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGiroAccount(BLGiroAccount blGiroAccount)
        {
            await _giroAccountService.AddGiroAccountAsync(blGiroAccount);
            return CreatedAtAction(nameof(CreateGiroAccount), new { id = blGiroAccount.IDGiroAccount }, blGiroAccount);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGiroAccount(int id, BLGiroAccount blGiroAccount)
        {
            if (id != blGiroAccount.IDGiroAccount)
            {
                return BadRequest();
            }

            await _giroAccountService.UpdateGiroAccountAsync(blGiroAccount);
            var updatedGiroAccount = await _giroAccountService.GetGiroAccountByIdAsync(id);
            return Ok(updatedGiroAccount);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGiroAccount(int id)
        {
            var giroAccountToDelete = await _giroAccountService.GetGiroAccountByIdAsync(id);
            if (giroAccountToDelete == null)
            {
                return NotFound();
            }

            await _giroAccountService.DeleteGiroAccountAsync(id);
            return Ok(giroAccountToDelete);
        }
    }
}
