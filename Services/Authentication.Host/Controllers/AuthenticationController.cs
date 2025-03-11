using Authentication.Application;
using Authentication.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationAppService _authenticationAppService;

        public AuthenticationController(IAuthenticationAppService authenticationAppService)
        {
            _authenticationAppService = authenticationAppService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authenticationAppService.RegisterAsync(model);
            if (!result.IsAuthenticated)
                return BadRequest(new ErrorModel
                {
                    IsAuthenticated = result.IsAuthenticated,
                    Message = result.Message
                });

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogIn([FromBody] LogInModel model)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authenticationAppService.GetTokenAsync(model);
            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }


        [HttpGet("get-all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _authenticationAppService.GetAllUsersAsync();
            return Ok(result);
        }


        [HttpGet("get-user/{code}")]
        public async Task<IActionResult> GetUserByCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return BadRequest("Code is required.");
            }

            var result = await _authenticationAppService.GetUserByCodeAsync(code);

            if (result == null)
            {
                return NotFound("User not found.");
            }

            return Ok(result);
        }


    }
}
