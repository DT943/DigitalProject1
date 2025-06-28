using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Authentication.Application;
using Authentication.Application.Dtos;
using Authentication.Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace Authentication.Host.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationAppService _authenticationAppService;
        private readonly IDepartmentAppService _departmentAppService;


        public AuthenticationController(IAuthenticationAppService authenticationAppService, IDepartmentAppService departmentAppService)
        {
            _authenticationAppService = authenticationAppService;
            _departmentAppService = departmentAppService;

        }


        [HttpPost("login")]

        public async Task<IActionResult> LogIn([FromBody] LogInModel model)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authenticationAppService.GetTokenAsync(model);
            if (!result.IsAuthenticated)
                return BadRequest(new ErrorModel
                {
                    IsAuthenticated = result.IsAuthenticated,
                    Message = result.Message
                });

            return Ok(result);
        }
        [HttpGet("get-all-users")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> GetAllUsers([FromQuery] SieveModel sieveModel)
        {
            var user = HttpContext.User;
            if (!user.IsInRole("SuperAdmin")) return Forbid();
            var result = await _authenticationAppService.GetAllUsersAsync(sieveModel, CurrentTenantId);
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

            var result = await _authenticationAppService.GetUserByCodeAsync(code, CurrentTenantId);

            if (result == null)
            {
                return NotFound("User not found.");
            }

            return Ok(result);
        }


        [HttpPut("ChangeUserAccountStatus/{userCode}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> ChangeUserStatus(string userCode)
        {
            var user = HttpContext.User;
            if (!user.IsInRole("SuperAdmin")) return Forbid();

            var result = await _authenticationAppService.ChangeUserStatusAsync(userCode, CurrentTenantId);
            if (!result.IsAuthenticated)
                return BadRequest(new ErrorModel
                {
                    IsAuthenticated = result.IsAuthenticated,
                    Message = result.Message
                });
            return  Ok(result);
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
                var result = await _authenticationAppService.AssignRoleToUserByServiceAsync(userCode, newRole, CurrentTenantId);
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
                var result = await _authenticationAppService.AddUserAsync(addUserDto, CurrentTenantId);
                if (!result.IsAuthenticated)
                    return BadRequest(new ErrorModel
                    {
                        IsAuthenticated = result.IsAuthenticated,
                        Message = result.Message
                    });
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
                var result = await _authenticationAppService.EditUserDepartment(userCode, newDepartment, CurrentTenantId);
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
                var result = await _authenticationAppService.UpdateUserAsync(newUser, userCode,CurrentTenantId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost("LogInWithOTP")]
        [AllowAnonymous]

        public async Task<IActionResult> LogInWithOTP([FromBody] LogInOTPModel model)
        {
            try
            {
                var result = await _authenticationAppService.LogInWithOTP(model);
                if (!result.IsAuthenticated)
                    return BadRequest(new ErrorModel
                    {
                        IsAuthenticated = result.IsAuthenticated,
                        Message = result.Message
                    });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        [HttpPost("FirstResetPassword")]

        [AllowAnonymous]
        public async Task<IActionResult> FirstResetPassword([FromBody] FirstResetLogInDto firestLogInDto)
        {
            try
            {
                var result = await _authenticationAppService.FirstResetPassword(firestLogInDto);
                if (!result.IsAuthenticated)
                    return BadRequest(new ErrorModel
                    {
                        IsAuthenticated = result.IsAuthenticated,
                        Message = result.Message
                    });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost("ResetPassword")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> ResetPassword([FromBody] FirstLogInDto firestLogInDto)
        {
            try
            {
                var result = await _authenticationAppService.ResetPassword(firestLogInDto, CurrentTenantId);
                if (!result.IsAuthenticated)
                    return BadRequest(new ErrorModel
                    {
                        IsAuthenticated = result.IsAuthenticated,
                        Message = result.Message
                    });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost("FakeDelete")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> FakeDelete([FromBody] UserFakeDeleteDto dto)
        {
            var user = HttpContext.User;
            if (!user.IsInRole("SuperAdmin")) return Forbid();
            try
            {
                var result = await _authenticationAppService.UserFakeDeleteAsync(dto, CurrentTenantId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }


        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordModel dto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var result = await _authenticationAppService.ForgotPassword(dto);
                if (!result.IsAuthenticated)
                    return BadRequest(new ErrorModel
                    {
                        IsAuthenticated = result.IsAuthenticated,
                        Message = result.Message
                    });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost("SetManagerToUser")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> SetManagerToUser(SetManagerToUserDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = HttpContext.User;
            if (!user.IsInRole("SuperAdmin")) return Forbid();

            try
            {
                var result = await _authenticationAppService.SetManagerToUser(dto);
                if (!result.IsAuthenticated)
                    return BadRequest(new ErrorModel
                    {
                        IsAuthenticated = result.IsAuthenticated,
                        Message = result.Message
                    });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
         }

        //Department 
        [HttpPost("CreateDepartment")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> CreateDepartment(CreateDepartmentDto department)
        {

            var user = HttpContext.User;
            if (!user.IsInRole("SuperAdmin")) return Forbid();
            try
            {
                var result = await _departmentAppService.Create(department);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPut("UpdateDepartment/{Code}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> UpdateDepartment(CreateDepartmentDto department)
        {

            var user = HttpContext.User;
            if (!user.IsInRole("SuperAdmin")) return Forbid();

            try
            {
                var result = await _departmentAppService.Update(department);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        [HttpGet("c")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> GetAllDepartment()
        {
            var user = HttpContext.User;
            if (!user.IsInRole("SuperAdmin")) return Forbid();

            var result = await _departmentAppService.GetAll();
            return Ok(result);
        }

        [HttpDelete("FakeDelete/{id}/{delete}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> FakeDelete(int id, bool delete)
        {
            var user = HttpContext.User;

            if (!user.IsInRole("SuperAdmin")) return Forbid();
            try
            {
                var result = await _departmentAppService.FakeDelete(delete, id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        [HttpDelete("Delete/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Delete(int id)
        {
            var user = HttpContext.User;

            if (!user.IsInRole("SuperAdmin")) return Forbid();
            try
            {
                var result = await _departmentAppService.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        [HttpGet("GetDepartmentByCode/{code}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> GetDepartmentByCode(string code)
        {
            var user = HttpContext.User;
            if (!user.IsInRole("SuperAdmin")) return Forbid();

            if (string.IsNullOrWhiteSpace(code))
            {
                return BadRequest("Code is required.");
            }

            var result = await _departmentAppService.GetByCode(code);

            if (result == null)
            {
                return NotFound("Department not found.");
            }

            return Ok(result);
        }
        [HttpGet("GetDepartmentById/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> GetDepartmentId(int id)
        {
            var user = HttpContext.User;
            if (!user.IsInRole("SuperAdmin")) return Forbid();

            var result = await _departmentAppService.Get(id);

            if (result == null)
            {
                return NotFound("Department not found.");
            }

            return Ok(result);
        }
        protected int CurrentTenantId
        {
            get
            {
                var tenantClaim = HttpContext.User.FindFirst("tenant_id")?.Value;
                if (string.IsNullOrEmpty(tenantClaim))
                    throw new UnauthorizedAccessException("TenantId claim missing.");
                if (!int.TryParse(tenantClaim, out int tenantId))
                    throw new UnauthorizedAccessException("TenantId claim is not a valid integer.");

                return int.Parse(tenantClaim);
            }
        }
    }
}