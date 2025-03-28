using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Authentication.Application;
using Authentication.Application.Dtos;
using Authentication.Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model)
        {
            var user = HttpContext.User;
            if (!user.IsInRole("SuperAdmin")) return Forbid();

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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> GetAllUsers()
        {
            var user = HttpContext.User;
            if (!user.IsInRole("SuperAdmin")) return Forbid();
            var result = await _authenticationAppService.GetAllUsersAsync();
            return Ok(result);
        }


        [HttpGet("get-all-roles")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> GetAllRoles()
        {
            var user = HttpContext.User;
            if (!user.IsInRole("SuperAdmin")) return Forbid();
            var result = await _authenticationAppService.GetAllRolesAsync();
            return Ok(result);
        }


        [HttpGet("get-user/{code}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> GetUserByCode(string code)
        {
            var user = HttpContext.User;
            if (!user.IsInRole("SuperAdmin")) return Forbid();

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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> AssignRolesToUser(string userCode, [FromBody] List<string> roles)
        {
            var user = HttpContext.User;
            if (!user.IsInRole("SuperAdmin")) return Forbid();

            if (string.IsNullOrWhiteSpace(userCode) || roles == null || !roles.Any())
            {
                return BadRequest("User code and at least one role are required.");
            }

            var result = await _authenticationAppService.AssignRolesToUserAsync(userCode, roles);
            return Ok(result);
        }

        [HttpPut("ChangeUserAccountStatus/{userCode}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> ChangeUserStatus(string userCode)
        {
            var user = HttpContext.User;
            if (!user.IsInRole("SuperAdmin")) return Forbid();

            var result = await _authenticationAppService.ChangeUserStatusAsync(userCode);
            return result ? Ok("User status updated successfully.") : BadRequest("Failed to update user status.");
        }

        [HttpPost("AssignServiceRoleToUser/{userCode}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> AssignRoleToUserByService(string userCode, [FromBody] string newRole)
        {
            var user = HttpContext.User;
            if (!user.IsInRole("SuperAdmin")) return Forbid();

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
        [HttpPost("AddNewUser")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> AddNewUser(AddUserDto addUserDto)
        {
            var user = HttpContext.User;
            if (!user.IsInRole("SuperAdmin")) return Forbid();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var result = await _authenticationAppService.AddUserAsync(addUserDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("EditUserDepartment/{userCode}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> EditUserDepartment(string userCode, [FromBody] string newDepartment)
        {
            var user = HttpContext.User;
            if (!user.IsInRole("SuperAdmin")) return Forbid();

            try
            {
                var result = await _authenticationAppService.EditUserDepartment(userCode, newDepartment);
                return Ok( result );
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        [HttpPut("UpdateUserProfile/{userCode}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> UpdateUserProfile(string userCode, [FromBody] UpdateUserDto newUser)
        {
            try
            {
                var result = await _authenticationAppService.UpdateUserAsync(newUser, userCode);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost("LogInWithOTP")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> LogInWithOTP([FromBody] LogInModel model)
        {
            try
            {
                var result = await _authenticationAppService.LogInWithOTP(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        [HttpPost("ResetPassword")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> ResetPassword([FromBody] FirestLogInDto firestLogInDto)
        {
            try
            {
                var result = await _authenticationAppService.ResetPassword(firestLogInDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}