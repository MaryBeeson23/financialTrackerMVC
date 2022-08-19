using Microsoft.AspNetCore.Mvc;
using FinancialTrackerMVC.Services.SavingsService;
using FinancialTrackerMVC.Models.Savings;

namespace FinancialTrackerMVC.Controllers
{
    public class SavingsController : ControllerBase
    {
        private readonly ISavings _service;
        public SavingsController(ISavings SavingsService)
        {
            _service = SavingsService;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSavingsAsync([FromBody] SavingsCreate model) {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _service.CreateSavingsAsync(model)) {
                return Ok("Savings goal has been created successfully.");
            }
            return BadRequest("Sorry, savings goal could not be created.");
        }

        [HttpGet]
        [ProducesResponseType(typeof(SavingsDetail), 200)]
        public async Task<IActionResult> GetAllSavingsAsync() {
            return Ok(await _service.GetAllSavingsAsync());
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(SavingsDetail), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSavingsByIdAsync([FromRoute] int id) {
            var save = await _service.GetSavingsByIdAsync(id);
            if (save == default) {
                return NotFound();
            }
            return Ok(save);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateSavingsAsync([FromRoute] int id, [FromBody] SavingsUpdate model) {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _service.UpdateSavingsAsync(id, model)) {
                return Ok("Savings goal has been updated successfully.");
            }
            return BadRequest("Sorry, savings goal could not be updated.");
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteSavingsByIdAsync([FromRoute] int id) {
            return await _service.DeleteSavingsAsync(id) ?
            Ok($"Savings goal with ID {id} has been deleted successfully.") :
            BadRequest($"Sorry, savings goal with ID {id} could not be deleted.");
        }
    }
}