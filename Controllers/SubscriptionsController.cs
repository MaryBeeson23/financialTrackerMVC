using Microsoft.AspNetCore.Mvc;
using FinancialTrackerMVC.Services.SubscriptionsService;
using FinancialTrackerMVC.Models.Subscriptions;

namespace FinancialTrackerMVC.Controllers
{
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISubscriptions _service;
        public SubscriptionsController(ISubscriptions subsService)
        {
            _service = subsService;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSubscriptionAsync([FromBody] SubscriptionsCreate model) {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _service.CreateSubscriptionAsync(model)) {
                return Ok("Subscription bill has been created successfully.");
            }
            return BadRequest("Sorry, subscription bill could not be created.");
        }

        [HttpGet]
        [ProducesResponseType(typeof(SubscriptionsDetail), 200)]
        public async Task<IActionResult> GetAllSubscriptionsAsync() {
            return Ok(await _service.GetAllSubscriptionsAsync());
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(SubscriptionsDetail), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSubscriptionsByIdAsync([FromRoute] int id) {
            var subs = await _service.GetSubscriptionsByIdAsync(id);
            if (subs == default) {
                return NotFound();
            }
            return Ok(subs);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateSubscriptionsAsync([FromRoute] int id, [FromBody] SubscriptionsUpdate model) {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _service.UpdateSubscriptionsAsync(id, model)) {
                return Ok("Subscription ill has been updated successfully.");
            }
            return BadRequest("Sorry, subscription bill could not be updated.");
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteSubscriptionsByIdAsync([FromRoute] int id) {
            return await _service.DeleteSubscriptionsAsync(id) ?
            Ok($"Subscription bill with ID {id} has been deleted successfully.") :
            BadRequest($"Sorry, subscription bill with ID {id} could not be deleted.");
        }
    }
}