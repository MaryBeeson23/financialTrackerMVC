// using Microsoft.AspNetCore.Mvc;
// using FinancialTrackerMVC.Services.CreditCardsService;
// using FinancialTrackerMVC.Models.CreditCards;

// namespace FinancialTrackerMVC.Controllers
// {
//     public class CreditCardsController : ControllerBase
//     {
//         private readonly ICreditCards _service;
//         public CreditCardsController(ICreditCards credService)
//         {
//             _service = credService;
//         }
//         [HttpPost]
//         [ProducesResponseType(StatusCodes.Status200OK)]
//         [ProducesResponseType(StatusCodes.Status400BadRequest)]
//         public async Task<IActionResult> CreateCreditCardsAsync([FromBody] CreditCardsCreate model) {
//             if (!ModelState.IsValid)
//             {
//                 return BadRequest(ModelState);
//             }

//             if (await _service.CreateCreditCardsAsync(model)) {
//                 return Ok("Credit card bill has been created successfully.");
//             }
//             return BadRequest("Sorry, credit card bill could not be created.");
//         }

//         [HttpGet]
//         [ProducesResponseType(typeof(CreditCardsDetail), 200)]
//         public async Task<IActionResult> GetAllCreditCardsAsync() {
//             return Ok(await _service.GetAllCreditCardsAsync());
//         }

//         [HttpGet("{id:int}")]
//         [ProducesResponseType(typeof(CreditCardsDetail), 200)]
//         [ProducesResponseType(StatusCodes.Status404NotFound)]
//         public async Task<IActionResult> GetCreditCardsByIdAsync([FromRoute] int id) {
//             var cred = await _service.GetCreditCardsByIdAsync(id);
//             if (cred == default) {
//                 return NotFound();
//             }
//             return Ok(cred);
//         }

//         [HttpPut("{id:int}")]
//         [ProducesResponseType(StatusCodes.Status200OK)]
//         [ProducesResponseType(StatusCodes.Status400BadRequest)]
//         public async Task<IActionResult> UpdateCreditCardsAsync([FromRoute] int id, [FromBody] CreditCardsUpdate model) {
//             if (!ModelState.IsValid)
//             {
//                 return BadRequest(ModelState);
//             }
//             if (await _service.UpdateCreditCardsAsync(id, model)) {
//                 return Ok("Credit card bill has been updated successfully.");
//             }
//             return BadRequest("Sorry, credit card bill could not be updated.");
//         }

//         [HttpDelete("{id:int}")]
//         [ProducesResponseType(StatusCodes.Status200OK)]
//         [ProducesResponseType(StatusCodes.Status400BadRequest)]
//         public async Task<IActionResult> DeleteCreditCardsByIdAsync([FromRoute] int id) {
//             return await _service.DeleteCreditCardsAsync(id) ?
//             Ok($"Credit card bill with ID {id} has been deleted successfully.") :
//             BadRequest($"Sorry, credit card bill with ID {id} could not be deleted.");
//         }
//     }
// }