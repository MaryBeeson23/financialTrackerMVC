// using Microsoft.AspNetCore.Mvc;
// using FinancialTrackerMVC.Services.MiscService;
// using FinancialTrackerMVC.Models.Misc;

// namespace FinancialTrackerMVC.Controllers
// {
//     public class MiscController : ControllerBase
//     {
//         private readonly IMisc _service;
//         public MiscController(IMisc miscService)
//         {
//             _service = miscService;
//         }
//         [HttpPost]
//         [ProducesResponseType(StatusCodes.Status200OK)]
//         [ProducesResponseType(StatusCodes.Status400BadRequest)]
//         public async Task<IActionResult> CreateMiscAsync([FromBody] MiscCreate model) {
//             if (!ModelState.IsValid)
//             {
//                 return BadRequest(ModelState);
//             }

//             if (await _service.CreateMiscAsync(model)) {
//                 return Ok("Miscellaneous bill has been created successfully.");
//             }
//             return BadRequest("Sorry, miscellaneous bill could not be created.");
//         }

//         [HttpGet]
//         [ProducesResponseType(typeof(MiscDetail), 200)]
//         public async Task<IActionResult> GetAllMiscAsync() {
//             return Ok(await _service.GetAllMiscAsync());
//         }

//         [HttpGet("{id:int}")]
//         [ProducesResponseType(typeof(MiscDetail), 200)]
//         [ProducesResponseType(StatusCodes.Status404NotFound)]
//         public async Task<IActionResult> GetMiscByIdAsync([FromRoute] int id) {
//             var misc = await _service.GetMiscByIdAsync(id);
//             if (misc == default) {
//                 return NotFound();
//             }
//             return Ok(misc);
//         }

//         [HttpPut("{id:int}")]
//         [ProducesResponseType(StatusCodes.Status200OK)]
//         [ProducesResponseType(StatusCodes.Status400BadRequest)]
//         public async Task<IActionResult> UpdateMiscAsync([FromRoute] int id, [FromBody] MiscUpdate model) {
//             if (!ModelState.IsValid)
//             {
//                 return BadRequest(ModelState);
//             }
//             if (await _service.UpdateMiscAsync(id, model)) {
//                 return Ok("Miscellaneous bill has been updated successfully.");
//             }
//             return BadRequest("Sorry, miscellaneous bill could not be updated.");
//         }

//         [HttpDelete("{id:int}")]
//         [ProducesResponseType(StatusCodes.Status200OK)]
//         [ProducesResponseType(StatusCodes.Status400BadRequest)]
//         public async Task<IActionResult> DeleteMiscByIdAsync([FromRoute] int id) {
//             return await _service.DeleteMiscAsync(id) ?
//             Ok($"Miscellaneous bill with ID {id} has been deleted successfully.") :
//             BadRequest($"Sorry, miscellaneous bill with ID {id} could not be deleted.");
//         }
//     }
// }