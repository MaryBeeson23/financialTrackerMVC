using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FinancialTrackerMVC.Services.UsersService;
using FinancialTrackerMVC.Models.Users;
// using FinancialTrackerMVC.Services.Token;
// using FinancialTrackerMVC.Models.Token;

namespace FinancialTrackerMVC.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUsers _userService;
        // private readonly ITokenService _tokenService;
        public UserController(IUsers userService 
        //ITokenService tokenService
        )
        {
            _userService = userService;
            // _tokenService = tokenService;
        }

        // [HttpPost("Token")]
        // [ProducesResponseType(typeof(TokenResponse), 200)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // public async Task<IActionResult> Token([FromBody] TokenRequest request) {
        //     if (!ModelState.IsValid) {
        //         return BadRequest(ModelState);
        //     }
        //     var tokenResponse = await _tokenService.GetTokenAsync(request);
        //     if (tokenResponse is null) {
        //         return BadRequest("Invalid username or password.");
        //     }
        //     return Ok(tokenResponse);
        // }

        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterUserAsync([FromBody] UsersRegister model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registerResult = await _userService.RegisterUserAsync(model);
            if (registerResult)
            {
                return Ok("The user has been registered successfully.");
            }
            return BadRequest("The user could not be registered.");
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(UsersDetail), 200)]
        public async Task<IActionResult> GetAllUsersAsync() 
        {
            return Ok(await _userService.GetAllUsersAsync());
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(UsersDetail), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserByIdAsync([FromRoute] int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [Authorize]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUserAsync([FromRoute] int id, [FromBody] UsersUpdate request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                return await _userService.UpdateUserAsync(id, request) ?
                Ok("The user has been updated successfully.") : 
                BadRequest("Sorry, the user could not be updated.");
        }

        [Authorize]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteUserAsync([FromRoute] int id)
        {
            return await _userService.DeleteUserAsync(id) ?
            Ok($"The user with ID {id} has been deleted successfully.") :
            BadRequest($"Sorry, the user with ID {id} could not be deleted.");
        }
    }
}