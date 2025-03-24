using Authentication.Application.Dtos;
using Authentication.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static Infrastructure.Domain.Consts;

namespace Authentication.Application
{
    public class AuthenticationAppService : IAuthenticationAppService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWT _jwt;
        private readonly IMapper _mapper;

        public AuthenticationAppService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<JWT> jwt, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwt.Value;
            _mapper = mapper;
        }
        public async Task<AuthenticationModel> RegisterAsync(RegisterModel model)
        {
            string userName = (model.FirstName + model.LastName).Replace(" ", "");

            if (await _userManager.FindByEmailAsync(model.Email) is not null)
                return new AuthenticationModel { Message = "Email is already registered!" };

            if (await _userManager.FindByNameAsync(userName) is not null)
                return new AuthenticationModel { Message = "Username is already registered!" };

            var user = new ApplicationUser
            {
                Code = "User-" + Guid.NewGuid().ToString("N"),
                IdentityNumber = model.IdentityNumber,
                PhoneNumber = model.PhoneNumber,
                UserName = userName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                FatherName = model.FatherName,
                MotherName = model.MotherName,
                Gender = Gender.Male,
                IsActive = true,
                LastLogIn = DateTime.UtcNow

            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var errors = string.Empty;

                foreach (var error in result.Errors)
                    errors += $"{error.Description},";

                return new AuthenticationModel
                {
                    IsAuthenticated = false,
                    Message = errors
                };
            }

            // Iterate over each service and create roles for each
            foreach (var service in Enum.GetNames(typeof(Infrastructure.Domain.Consts.ServiceName)))
            {
                var roleName = $"{service}-Officer";
                await _userManager.AddToRoleAsync(user, roleName);
            }

            var jwtSecurityToken = await CreateJwtToken(user);

            var userRoles = await _userManager.GetRolesAsync(user);


            return new AuthenticationModel
            {
                Message = "User has been created successfully.",
                Email = user.Email,
                ExpiresOn = jwtSecurityToken.ValidTo,
                Roles = userRoles,
                IsAuthenticated = true,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("userCode", user.Code.ToString())
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }

        public async Task<AuthenticationModel> GetTokenAsync(LogInModel model)
        {
            var authModel = new AuthenticationModel();

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                authModel.Message = "Email or Password is incorrect!";
                return authModel;
            }


            if (await _userManager.IsLockedOutAsync(user))
            {
                user.IsActive = !user.IsActive;
                var result = await _userManager.UpdateAsync(user);
                authModel.Message = "Your account is locked due to multiple failed login attempts.";
                return authModel;
            }

            if (!user.IsActive)
            {
                authModel.Message = "Your account is deactivated. Please contact support.";
                return authModel;
            }


            if (!await _userManager.CheckPasswordAsync(user, model.Password))
            {
                await _userManager.AccessFailedAsync(user); // Increase failed login attempts

                if (await _userManager.IsLockedOutAsync(user))
                {
                    authModel.Message = "Your account has been locked due to multiple failed login attempts.";
                }
                else
                {
                    authModel.Message = "Email or Password is incorrect!";
                }

                return authModel;
            }
            // Reset failed attempts count on successful login
            await _userManager.ResetAccessFailedCountAsync(user);


            user.LastLogIn = DateTime.UtcNow;
            var updateResult = await _userManager.UpdateAsync(user);

            var userRoles = await _userManager.GetRolesAsync(user);
            var jwtSecurityToken = await CreateJwtToken(user);

            authModel.Message = "User information has been retrieved successfully.";
            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Email = user.Email;
            authModel.FirstName = user.FirstName;
            authModel.ExpiresOn = jwtSecurityToken.ValidTo;
            authModel.Roles = userRoles;

            return authModel;
        }

        public async Task<IEnumerable<AuthenticationGetDto>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var userDtos = new List<AuthenticationGetDto>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var authDto = _mapper.Map<AuthenticationGetDto>(user);
                authDto.Roles = roles;
                userDtos.Add(authDto);
            }

            return userDtos;
        }


        public async Task<IEnumerable<string>> GetAllRolesAsync()
        {
            return await _roleManager.Roles.Select(r => r.Name).ToListAsync();
        }

        public async Task<AuthenticationGetDto> GetUserByCodeAsync(string code)
        {
            var users = await _userManager.Users.Where(x => x.Code.Equals(code)).FirstOrDefaultAsync();
            var existingRoles = await _userManager.GetRolesAsync(users);
            AuthenticationGetDto auth = _mapper.Map<AuthenticationGetDto>(users);
            auth.Roles = existingRoles;
            return auth;
        }

        public async Task<UserWithRole> AssignRolesToUserAsync(string userCode,  List<string> roles)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Code == userCode);



            var existingRoles = await _userManager.GetRolesAsync(user);
            var removeResult = await _userManager.RemoveFromRolesAsync(user, existingRoles);
 

            // Assign new roles one by one
            foreach (var role in roles)
            {
                var roleExists = await _roleManager.RoleExistsAsync(role);
                if (roleExists)
                {
                    var addRoleResult = await _userManager.AddToRoleAsync(user, role);

                }

            }

            // Get updated roles
            var userNewRoles = await _userManager.GetRolesAsync(user);



            return new UserWithRole
            {
                applicationUser = new GetUser
                {
                    Id = user.Id,
                    Code = user.Code,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    MotherName = user.MotherName,
                    FatherName = user.FatherName,
                },
                Roles = userNewRoles
            };  
        }
        public async Task<bool> ChangeUserStatusAsync(string userCode)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Code == userCode);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            user.IsActive = !user.IsActive;
            var result = await _userManager.UpdateAsync(user);

            return result.Succeeded;
        }

        public async Task<UserWithRole> AssignRoleToUserByServiceAsync(string userCode, string newRole)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Code == userCode);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            // Extract service name from the new role (before the '-')
            var newRoleParts = newRole.Split('-');
            if (newRoleParts.Length < 2)
            {
                throw new Exception("Invalid role format. Expected format: 'ServiceName-RoleName'");
            }
            var newService = newRoleParts[0]; // Extract the service name (e.g., "CMS" from "CMS-Admin")

            // Get user's existing roles
            var existingRoles = await _userManager.GetRolesAsync(user);

            // Filter roles that belong to the same service
            var rolesToRemove = existingRoles.Where(r => r.StartsWith($"{newService}-")).ToList();

            if (rolesToRemove.Any())
            {
                var removeResult = await _userManager.RemoveFromRolesAsync(user, rolesToRemove);
                if (!removeResult.Succeeded)
                {
                    throw new Exception($"Failed to remove existing roles from service {newService}");
                }
            }

            // Check if the new role exists before assigning
            var roleExists = await _roleManager.RoleExistsAsync(newRole);
            if (roleExists)
            {
                var addRoleResult = await _userManager.AddToRoleAsync(user, newRole);
                if (!addRoleResult.Succeeded)
                {
                    throw new Exception($"Failed to assign role {newRole} to user.");
                }
            }
            else
            {
                throw new Exception($"Role {newRole} does not exist.");
            }

            // Get updated roles
            var userNewRoles = await _userManager.GetRolesAsync(user);

            return new UserWithRole
            {
                applicationUser = new GetUser
                {
                    Id = user.Id,
                    Code = user.Code,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    MotherName = user.MotherName,
                    FatherName = user.FatherName,
                },
                Roles = userNewRoles
            };
        }

        public async Task<AuthenticationModel> AddUserAsync(AddUserDto newuser)
        {
            string userName = (newuser.FirstName + newuser.LastName).Replace(" ", "");

            if (await _userManager.FindByEmailAsync(newuser.Email) is not null)
                return new AuthenticationModel { Message = "Email is already exist!" };

            if (await _userManager.FindByNameAsync(userName) is not null)
                return new AuthenticationModel { Message = "Username is already exist!" };

            var user = new ApplicationUser
            {
                Code = "User-" + Guid.NewGuid().ToString("N"),
                IdentityNumber = " ",
                PhoneNumber = " ",
                UserName = userName,
                Email = newuser.Email,
                FirstName = newuser.FirstName,
                LastName = newuser.LastName,
                FatherName = " ",
                MotherName = " ",
                Gender = Gender.Male,
                IsActive = newuser.IsActive,
                LastLogIn = DateTime.MinValue,
                Department = newuser.Department,

            };

            var result = await _userManager.CreateAsync(user, "Hi@2025");

            if (!result.Succeeded)
            {
                var errors = string.Empty;

                foreach (var error in result.Errors)
                    errors += $"{error.Description},";

                return new AuthenticationModel
                {
                    IsAuthenticated = false,
                    Message = errors
                };
            }

            // Iterate over each service and create roles for each
            foreach (var service in Enum.GetNames(typeof(Infrastructure.Domain.Consts.ServiceName)))
            {
                var roleName = $"{service}-Officer";
                await _userManager.AddToRoleAsync(user, roleName);
            }
            if (!string.IsNullOrEmpty(newuser.Role))
            {
                var role = AssignRoleToUserByServiceAsync(user.Code, newuser.Role);
            }
            var userRoles = await _userManager.GetRolesAsync(user);


            return new AuthenticationModel
            {
                Message = "User has been created successfully.",
                Email = user.Email,
                Roles = userRoles,
                IsAuthenticated = true,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

    }
}

