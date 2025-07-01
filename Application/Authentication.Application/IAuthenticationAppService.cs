using Authentication.Application.Dtos;
using Authentication.Domain.Models;
using Sieve.Models;
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
        //done
        public Task<AuthenticationModelWithDetails> RegisterAsync(RegisterModel model);
        //done
        public Task<AuthenticationModel> GetTokenAsync(LogInModel model);
        //done 
        public Task<UserDashboardResultDto> GetAllUsersAsync(SieveModel sieveModel, int CurrentTenantId);
        //done
        public Task<AuthenticationGetDto> GetUserByCodeAsync(string code, int CurrentTenantId);
        //No tenant
        public Task<IEnumerable<string>> GetAllRolesAsync();
        //No tenant
        public Task<UserWithRole> AssignRolesToUserAsync(string userCode, List<string> roles, int CurrentTenantId);

        //done
        Task<UserWithRole> AssignRoleToUserByServiceAsync(string userCode, string newRole, int CurrentTenantId);
        //done
        Task<AuthenticationModel> ChangeUserStatusAsync(string userCode, int CurrentTenantId);
        //done
        Task<AuthenticationModel> AddUserAsync(AddUserDto newuser , int CurrentTenantId);

        //problem
        Task<AuthenticationModelWithDetails> AddB2BUserAsync(AddUserDto newuser);


        //problem
        Task<AuthenticationModelWithDetails> AddLoyaltyUserAsync(AddUserDto newuser);

        Task<AuthenticationModel> EditUserDepartment(string userCode, string newDepartment, int CurrentTenantId);
        
        Task<AuthenticationModel> UpdateUserAsync(UpdateUserDto newUser, string userCode, int CurrentTenantId);
        
        
        //No Tenant
        Task<AuthenticationModel> LogInWithOTP(LogInOTPModel model);

        //done
        Task<AuthenticationModel> ResetPassword(FirstLogInDto firestLogInDto, int CurrentTenantId);

        //No Tenant
        Task<AuthenticationModel> FirstResetPassword(FirstResetLogInDto firestLogInDto);

        //done
        Task<AuthenticationModel> UserFakeDeleteAsync(UserFakeDeleteDto dto, int CurrentTenantId);

        //No Tenant
        Task<AuthenticationModel> ForgotPassword(ForgotPasswordModel dto);

        //No Tenant 
        Task<AuthenticationModel> SetManagerToUser(SetManagerToUserDto dto);

        //No Tenant 

        Task<bool> CheckEmail(string email);
        //No Tenant 

        Task<bool> CheckUserName(string FirstName, string LastName);
    }
}
