using Microsoft.AspNetCore.Mvc;
using FinancialTrackerMVC.Services.BillsService;
using FinancialTrackerMVC.Models.Bills;

namespace FinancialTrackerMVC.Controllers
{
    public class BillsController : ControllerBase
    {
        private readonly IBills _service;
        public BillsController(IBills billsService)
        {
            _service = billsService;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateBillsAsync([FromBody] BillsCreate model) {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _service.CreateBillsAsync(model)) {
                return Ok("Bill has been created successfully.");
            }
            return BadRequest("Sorry, bill could not be created.");
        }

        [HttpGet]
        [ProducesResponseType(typeof(BillsDetail), 200)]
        public async Task<IActionResult> GetAllBillsAsync() {
            return Ok(await _service.GetAllBillsAsync());
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(BillsDetail), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBillsByIdAsync([FromRoute] int id) {
            var bill = await _service.GetBillsByIdAsync(id);
            if (bill == default) {
                return NotFound();
            }
            return Ok(bill);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateBillsAsync([FromRoute] int id, [FromBody] BillsUpdate model) {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _service.UpdateBillsAsync(id, model)) {
                return Ok("Bill has been updated successfully.");
            }
            return BadRequest("Sorry, bill could not be updated.");
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteBillsByIdAsync([FromRoute] int id) {
            return await _service.DeleteBillsAsync(id) ?
            Ok($"Bill with ID {id} has been deleted successfully.") :
            BadRequest($"Sorry, bill with ID {id} could not be deleted.");
        }
    }
}
