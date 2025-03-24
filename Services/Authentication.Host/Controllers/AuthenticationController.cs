using Authentication.Application;
using Authentication.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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


        [HttpGet("get-all-roles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var result = await _authenticationAppService.GetAllRolesAsync();
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


        [HttpPost("assign-roles/{userCode}")]
        public async Task<IActionResult> AssignRolesToUser(string userCode, [FromBody] List<string> roles)
        {
            if (string.IsNullOrWhiteSpace(userCode) || roles == null || !roles.Any())
            {
                return BadRequest("User code and at least one role are required.");
            }

            var result = await _authenticationAppService.AssignRolesToUserAsync(userCode, roles);
            return Ok(result);
        }
        
        [HttpPut("ChangeUserAccountStatus/{userCode}")]
        public async Task<IActionResult> ChangeUserStatus(string userCode)
        {
            var result = await _authenticationAppService.ChangeUserStatusAsync(userCode);
            return result ? Ok("User status updated successfully.") : BadRequest("Failed to update user status.");
        }

        [HttpPost("AssignServiceRoleToUser/{userCode}")]
        public async Task<IActionResult> AssignRoleToUserByService(string userCode, [FromBody] string newRole)
        {
            if (string.IsNullOrWhiteSpace(userCode) || string.IsNullOrWhiteSpace(newRole))
                return BadRequest("User code and role are required.");

            try
            {
                var result = await _authenticationAppService.AssignRoleToUserByServiceAsync(userCode, newRole);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
