// using Microsoft.AspNetCore.Mvc;
// using FinancialTrackerMVC.Services.RentAndUtilitiesService;
// using FinancialTrackerMVC.Models.RentAndUtilities;

// namespace FinancialTrackerMVC.Controllers
// {
//     public class RentAndUtilitiesController : ControllerBase
//     {
//         private readonly IRentAndUtilities _service;
//         public RentAndUtilitiesController(IRentAndUtilities renuService)
//         {
//             _service = renuService;
//         }
//         [HttpPost]
//         [ProducesResponseType(StatusCodes.Status200OK)]
//         [ProducesResponseType(StatusCodes.Status400BadRequest)]
//         public async Task<IActionResult> CreateRentAndUtilitiesAsync([FromBody] RentAndUtilitiesCreate model) {
//             if (!ModelState.IsValid)
//             {
//                 return BadRequest(ModelState);
//             }

//             if (await _service.CreateRentAndUtilitiesAsync(model)) {
//                 return Ok("Rent or utility bill has been created successfully.");
//             }
//             return BadRequest("Sorry, rent or utility bill could not be created.");
//         }

//         [HttpGet]
//         [ProducesResponseType(typeof(RentAndUtilitiesDetail), 200)]
//         public async Task<IActionResult> GetAllRentAndUtilitiesAsync() {
//             return Ok(await _service.GetAllRentAndUtilitiesAsync());
//         }

//         [HttpGet("{id:int}")]
//         [ProducesResponseType(typeof(RentAndUtilitiesDetail), 200)]
//         [ProducesResponseType(StatusCodes.Status404NotFound)]
//         public async Task<IActionResult> GetRentAndUtilitiesByIdAsync([FromRoute] int id) {
//             var renu = await _service.GetRentAndUtilitiesByIdAsync(id);
//             if (renu == default) {
//                 return NotFound();
//             }
//             return Ok(renu);
//         }

//         [HttpPut("{id:int}")]
//         [ProducesResponseType(StatusCodes.Status200OK)]
//         [ProducesResponseType(StatusCodes.Status400BadRequest)]
//         public async Task<IActionResult> UpdateRentAndUtilitiesAsync([FromRoute] int id, [FromBody] RentAndUtilitiesUpdate model) {
//             if (!ModelState.IsValid)
//             {
//                 return BadRequest(ModelState);
//             }
//             if (await _service.UpdateRentAndUtilitiesAsync(id, model)) {
//                 return Ok("Rent or utility bill has been updated successfully.");
//             }
//             return BadRequest("Sorry, rent or utility bill could not be updated.");
//         }

//         [HttpDelete("{id:int}")]
//         [ProducesResponseType(StatusCodes.Status200OK)]
//         [ProducesResponseType(StatusCodes.Status400BadRequest)]
//         public async Task<IActionResult> DeleteRentAndUtilitiesByIdAsync([FromRoute] int id) {
//             return await _service.DeleteRentAndUtilitiesAsync(id) ?
//             Ok($"Rent or utility bill with ID {id} has been deleted successfully.") :
//             BadRequest($"Sorry, rent or utility bill with ID {id} could not be deleted.");
//         }
//     }
// }