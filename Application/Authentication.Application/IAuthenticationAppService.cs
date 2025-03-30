using Authentication.Application.Dtos;
using Authentication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Application
{
    public interface IAuthenticationAppService
    {
        public Task<AuthenticationModel> RegisterAsync(RegisterModel model);

        public Task<AuthenticationModel> GetTokenAsync(LogInModel model);

        public Task<IEnumerable<AuthenticationGetDto>> GetAllUsersAsync();

        public Task<AuthenticationGetDto> GetUserByCodeAsync(string code);

        public Task<IEnumerable<string>> GetAllRolesAsync();

        public Task<UserWithRole> AssignRolesToUserAsync(string userCode, List<string> roles);


        Task<UserWithRole> AssignRoleToUserByServiceAsync(string userCode, string newRole);

        Task<AuthenticationModel> ChangeUserStatusAsync(string userCode);
        Task<AuthenticationModel> AddUserAsync(AddUserDto newuser);
        Task<AuthenticationModel> EditUserDepartment(string userCode, string newDepartment);
        Task<AuthenticationModel> UpdateUserAsync(UpdateUserDto newUser, string userCode);
        //Task<AuthenticationModel> SendOTP(string lastPassword, ClaimsPrincipal user);
        Task<AuthenticationModel> LogInWithOTP(LogInModel model);
        Task<AuthenticationModel> ResetPassword(FirstLogInDto firestLogInDto);

        Task<AuthenticationGetDto> UserFakeDeleteAsync(UserFakeDeleteDto dto);
    }
}
