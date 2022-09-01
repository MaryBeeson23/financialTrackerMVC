// using Microsoft.AspNetCore.Mvc;
// using FinancialTrackerMVC.Services.MedicalAndInsuranceService;
// using FinancialTrackerMVC.Models.MedicalAndInsurance;

// namespace FinancialTrackerMVC.Controllers
// {
//     public class MedicalAndInsuranceController : ControllerBase
//     {
//         private readonly IMedicalAndInsurance _service;
//         public MedicalAndInsuranceController(IMedicalAndInsurance mediService)
//         {
//             _service = mediService;
//         }
//         [HttpPost]
//         [ProducesResponseType(StatusCodes.Status200OK)]
//         [ProducesResponseType(StatusCodes.Status400BadRequest)]
//         public async Task<IActionResult> CreateMedicalAndInsuranceAsync([FromBody] MedicalAndInsuranceCreate model) {
//             if (!ModelState.IsValid)
//             {
//                 return BadRequest(ModelState);
//             }

//             if (await _service.CreateMedicalAndInsuranceAsync(model)) {
//                 return Ok("Medical or insurance bill has been created successfully.");
//             }
//             return BadRequest("Sorry, medical or insurance bill could not be created.");
//         }

//         [HttpGet]
//         [ProducesResponseType(typeof(MedicalAndInsuranceDetail), 200)]
//         public async Task<IActionResult> GetAllMedicalAndInsuranceAsync() {
//             return Ok(await _service.GetAllMedicalAndInsuranceAsync());
//         }

//         [HttpGet("{id:int}")]
//         [ProducesResponseType(typeof(MedicalAndInsuranceDetail), 200)]
//         [ProducesResponseType(StatusCodes.Status404NotFound)]
//         public async Task<IActionResult> GetMedicalAndInsuranceByIdAsync([FromRoute] int id) {
//             var medi = await _service.GetMedicalAndInsuranceByIdAsync(id);
//             if (medi == default) {
//                 return NotFound();
//             }
//             return Ok(medi);
//         }

//         [HttpPut("{id:int}")]
//         [ProducesResponseType(StatusCodes.Status200OK)]
//         [ProducesResponseType(StatusCodes.Status400BadRequest)]
//         public async Task<IActionResult> UpdateMedicalAndInsuranceAsync([FromRoute] int id, [FromBody] MedicalAndInsuranceUpdate model) {
//             if (!ModelState.IsValid)
//             {
//                 return BadRequest(ModelState);
//             }
//             if (await _service.UpdateMedicalAndInsuranceAsync(id, model)) {
//                 return Ok("Medical or insurance bill has been updated successfully.");
//             }
//             return BadRequest("Sorry, medical or insurance bill could not be updated.");
//         }

//         [HttpDelete("{id:int}")]
//         [ProducesResponseType(StatusCodes.Status200OK)]
//         [ProducesResponseType(StatusCodes.Status400BadRequest)]
//         public async Task<IActionResult> DeleteMedicalAndInsuranceByIdAsync([FromRoute] int id) {
//             return await _service.DeleteMedicalAndInsuranceAsync(id) ?
//             Ok($"Medical or insurance bill with ID {id} has been deleted successfully.") :
//             BadRequest($"Sorry, medical or insurance bill with ID {id} could not be deleted.");
//         }
//     }
// }