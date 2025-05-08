using Authentication.Application.Dtos;
using Authentication.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using Notification.Application;
using Sieve.Models;
using Sieve.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using static Infrastructure.Domain.Consts;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Authentication.Application
{
    public class AuthenticationAppService : IAuthenticationAppService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWT _jwt;
        private readonly IMapper _mapper;
        private readonly IEmailAppService _emailService;
        private readonly ISieveProcessor _sieveProcessor;
        string key = "MySuperSecretKey!";
        private readonly IConfiguration _configuration;

        public AuthenticationAppService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<JWT> jwt, IMapper mapper, ISieveProcessor sieveProcessor, IEmailAppService emailService, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwt.Value;
            _mapper = mapper;
            _emailService = emailService;
            _sieveProcessor = sieveProcessor;
            _configuration = configuration;

        }

        private static byte[] GetKeyBytes(string key, int length)
        {
            using SHA256 sha = SHA256.Create();
            byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(key));
            byte[] result = new byte[length];
            Array.Copy(hash, result, length);
            return result;
        }

        public static string Encrypt(string plainText, string key)
        {
            byte[] aesKey = GetKeyBytes(key, 32); // 256-bit key
            byte[] aesIV = GetKeyBytes(key, 16);  // 128-bit IV

            using Aes aesAlg = Aes.Create();
            aesAlg.Key = aesKey;
            aesAlg.IV = aesIV;

            using MemoryStream msEncrypt = new();
            using (CryptoStream csEncrypt = new(msEncrypt, aesAlg.CreateEncryptor(), CryptoStreamMode.Write))
            using (StreamWriter swEncrypt = new(csEncrypt))
            {
                swEncrypt.Write(plainText);
            }

            // ✅ Now the MemoryStream is fully written
            return Convert.ToBase64String(msEncrypt.ToArray());
        }

        public static string Decrypt(string cipherText, string key)
        {
            byte[] aesKey = GetKeyBytes(key, 32);
            byte[] aesIV = GetKeyBytes(key, 16);

            using Aes aesAlg = Aes.Create();
            aesAlg.Key = aesKey;
            aesAlg.IV = aesIV;

            using MemoryStream msDecrypt = new(Convert.FromBase64String(cipherText));
            using CryptoStream csDecrypt = new(msDecrypt, aesAlg.CreateDecryptor(), CryptoStreamMode.Read);
            using StreamReader srDecrypt = new(csDecrypt);
            return srDecrypt.ReadToEnd();
        }

        public async Task<AuthenticationModel> RegisterAsync(RegisterModel model)
        {
            string userName = (model.FirstName + model.LastName).Replace(" ", "");

            if (await _userManager.FindByEmailAsync(model.Email) is not null)
                return new AuthenticationModel { Message = "Email is already registered!" ,IsAuthenticated = false };

            if (await _userManager.FindByNameAsync(userName) is not null)
                return new AuthenticationModel { Message = "Username is already registered!" , IsAuthenticated = false };

            var user = new ApplicationUser
            {
                Code = "User-" + Guid.NewGuid().ToString("N"),
                UserName = userName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                IsActive = true,
                IsLocked = false,
                IsFrozed = false,
                LastLogIn = DateTime.Now
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
                LastName = user.LastName,
               
            };
        }

        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();
            
            foreach (var role in roles)
                roleClaims.Add(new Claim(ClaimTypes.Role, role));

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

            if (user == null|| user.IsDeleted)
            {
                authModel.Message = "User Not exist!";
                authModel.IsAuthenticated = false;
                return authModel;
            }
            if (!await _userManager.CheckPasswordAsync(user, model.Password))
            {
                await _userManager.AccessFailedAsync(user); // Increase failed login attempts

                if (await _userManager.IsLockedOutAsync(user))
                {
                    authModel.IsAuthenticated = false;
                    authModel.Message = "Your account has been locked due to multiple failed login attempts.";
                }
                else
                {
                    authModel.IsAuthenticated = false;
                    authModel.Message = "Email or Password is incorrect!";
                }

                return authModel;
            }

            if (user.NumberOfLogIn == 0 && user.IsFrozed)
            {
                if (!await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    return new AuthenticationModel { Message = "Invalid password!", IsAuthenticated = false };
                }

                if (user.OTPExpiration> DateTime.Now)
                {
                    return new AuthenticationModel { Message = "OTP is already send", IsAuthenticated = true };
                }
                //var otp = GenerateSecurePassword();
                Random random = new Random();
                var otp = random.Next(100000, 999999).ToString();

                var expirationTime = DateTime.Now.AddMinutes(3);

                //Console.WriteLine(otp);

                user.OTP = otp;
                user.OTPExpiration = expirationTime;
                await _userManager.UpdateAsync(user);

                string subject = "Your One-Time Password (OTP), FirstLogInToSystem";
                await _emailService.SendEmailAsync(user.Email, subject, otp, user.FirstName);
                authModel.IsAuthenticated = true;
                authModel.NumberOfLogin = user.NumberOfLogIn;
                authModel.Token = Encrypt(user.Email, this.key);
                authModel.Message = "Please reset OTP at the first time you get to system, Check your email!";
                return authModel;
            }

            if (DateTime.Now - user.LastLogIn > TimeSpan.FromDays(3))
            {
                user.IsFrozed = true;
                user.IsActive = false;
                if (!await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    return new AuthenticationModel { Message = "Invalid password!", IsAuthenticated = false };
                }

                Random random = new Random();
                var otp = random.Next(100000, 999999).ToString();

                // Set OTP expiration time (e.g., 3 minutes from now)
                var expirationTime = DateTime.Now.AddMinutes(3);

                // Store OTP and expiration time (You may save it in the database or cache)
                user.OTP = otp;
                user.OTPExpiration = expirationTime;
                await _userManager.UpdateAsync(user);

                // Email subject and body
                string subject = "Your One-Time Password (OTP),The last login was a long time ago.";

                await _emailService.SendEmailAsync(user.Email, subject, otp, user.FirstName);
                authModel.IsAuthenticated = true;
                authModel.Message = "Please reset OTP, The last login was a long time ago, Check your email!";
                return authModel;
            }
            if (await _userManager.IsLockedOutAsync(user) || user.IsLocked)
            {
                user.IsActive = !user.IsActive;
                user.IsLocked = true;
                authModel.IsAuthenticated = false;
                var result = await _userManager.UpdateAsync(user);
                authModel.Message = "Your account is locked due to multiple failed login attempts.";
                return authModel;
            }
            if (!user.IsActive)
            {
                authModel.IsAuthenticated = false;
                authModel.Message = "Your account is deactivated. Please contact support.";
                return authModel;
            }


            // Reset failed attempts count on successful login
            await _userManager.ResetAccessFailedCountAsync(user);
            user.LastLogIn = DateTime.Now;
            user.NumberOfLogIn += 1;

            var updateResult = await _userManager.UpdateAsync(user);

            var userRoles = await _userManager.GetRolesAsync(user);
            var jwtSecurityToken = await CreateJwtToken(user);

            authModel.Message = "User information has been retrieved successfully.";
            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Email = user.Email;
            authModel.Code = user.Code;
            authModel.FirstName = user.FirstName;
            authModel.ExpiresOn = jwtSecurityToken.ValidTo;
            authModel.Roles = userRoles;
            authModel.ManagerCode = user.ManagerCode;
            authModel.NumberOfLogin = user.NumberOfLogIn;
            return authModel;
        }
        public async Task<AuthenticationModel> AddUserAsync(AddUserDto newuser)
        {
            string userName = (newuser.FirstName + newuser.LastName).Replace(" ", "");

            if (await _userManager.FindByEmailAsync(newuser.Email) is not null)
                return new AuthenticationModel { Message = "Email is already exist!", IsAuthenticated = false };

            if (await _userManager.FindByNameAsync(userName) is not null)
                return new AuthenticationModel { Message = "Username is already exist!" , IsAuthenticated = false };

            var user = new ApplicationUser
            {
                Code = "User-" + Guid.NewGuid().ToString("N"),
                UserName = userName,
                Email = newuser.Email,
                FirstName = newuser.FirstName,
                LastName = newuser.LastName,
                IsLocked = false,
                IsActive = false,
                IsFrozed = true,
                LastOTPChecked = DateTime.MaxValue,
                LastLogIn = DateTime.MinValue,
                Department = newuser.Department,

            };
            var staticPassword = GenerateSecurePassword();
            var result = await _userManager.CreateAsync(user, staticPassword);

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

            var userRoles = await _userManager.GetRolesAsync(user);

            string subject = "Your Account Has Been Created, Welcome to our website.";

            await _emailService.SendEmailAsync(newuser.Email, subject, staticPassword, newuser.FirstName);

 
            return new AuthenticationModel
            {
                Message = "User has been created successfully.",
                Email = user.Email,
                Roles = userRoles,
                IsAuthenticated = true,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = null
            };
        }
        private string GenerateSecurePassword()
        {
            Random random = new Random();

            // 1. Generate OTP (6 digits)
            string otp = random.Next(100000, 999999).ToString();

            // 2. Ensure at least one lowercase, one uppercase, and one special character
            char lowercase = (char)random.Next('a', 'z' + 1);
            char uppercase = (char)random.Next('A', 'Z' + 1);
            char specialChar = "!@#$%^&*_-=+."[random.Next(0, 12)];

            // 3. Combine all required parts
            string combined = $"{lowercase}{uppercase}{specialChar}{otp}";

            // 4. Shuffle for better randomness
            string shuffled = new string(combined.OrderBy(c => random.Next()).ToArray());

            return shuffled;
        }
        public async Task <AuthenticationModel> FirstResetPassword(FirstResetLogInDto firestLogInDto)
        {
            string email = Decrypt(firestLogInDto.Token, this.key);
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return new AuthenticationModel { Message = "User not found!", IsAuthenticated = false };
            } 
            else
            {
                if (user.LastOTPChecked > DateTime.Now)
                {
                    return new AuthenticationModel { Message = "You should send your OTP!", IsAuthenticated = false };

                }
            }
            // Ensure new password and confirm password match
            if (firestLogInDto.Password != firestLogInDto.ConfirmPassword)
            {
                return new AuthenticationModel { Message = "New passwords do not match!", IsAuthenticated = false };
            }

            // Update user password
            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, resetToken, firestLogInDto.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return new AuthenticationModel { Message = $"Password reset failed: {errors}", IsAuthenticated = false };
            }
            user.IsFrozed = false;
            user.IsActive = true;
            user.LastLogIn = DateTime.Now;
            user.LastOTPChecked = DateTime.MaxValue;
            await _userManager.UpdateAsync(user);

            return new AuthenticationModel
            {
                Message = "Password has been successfully reset. You can now log in with your new password.",
                IsAuthenticated = true,
                Email = email
            };
        }
        public async Task<AuthenticationModel> ResetPassword(FirstLogInDto firestLogInDto)
        {
            var user = await _userManager.FindByEmailAsync(firestLogInDto.Email);

            if (user == null)
            {
                return new AuthenticationModel { Message = "User not found!", IsAuthenticated = false };
            }

            if (user.NumberOfLogIn > 0)
            {
                // Ensure the provided OldPassword is the StaticPassword from Consts
                var passwordValid = await _userManager.CheckPasswordAsync(user, firestLogInDto.OldPassword);
                if (!passwordValid)
                    return new AuthenticationModel { Message = "Invalid old password!", IsAuthenticated = false };
            }
            else
            {
                if (user.LastOTPChecked > DateTime.Now)
                {
                    return new AuthenticationModel { Message = "You should send your OTP!", IsAuthenticated = false };

                }
            }
            // Ensure new password and confirm password match
            if (firestLogInDto.Password != firestLogInDto.ConfirmPassword)
            {
                return new AuthenticationModel { Message = "New passwords do not match!", IsAuthenticated = false };
            }

            // Update user password
            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, resetToken, firestLogInDto.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return new AuthenticationModel { Message = $"Password reset failed: {errors}", IsAuthenticated = false };
            }
            user.IsFrozed = false;
            user.IsActive = true;
            user.LastLogIn = DateTime.Now;
            user.LastOTPChecked = DateTime.MaxValue;
            await _userManager.UpdateAsync(user);

            return new AuthenticationModel
            {
                Message = "Password has been successfully reset. You can now log in with your new password.",
                IsAuthenticated = true,
                Email = firestLogInDto.Email
            };
        }
        public async Task<AuthenticationModel> LogInWithOTP(LogInOTPModel model)
        {
             var existuser = await _userManager.FindByEmailAsync(Decrypt(model.Token, this.key));

            if (existuser == null || existuser.IsDeleted)
            {
                return new AuthenticationModel { Message = "User not found!", IsAuthenticated = false };
            }

            // Check if the provided OTP matches the stored one
            if (existuser.OTP != model.Password) // StaticPassword is being used as OTP here
            {
                return new AuthenticationModel { Message = "Invalid OTP!", IsAuthenticated = false };
            }

            // Check if the OTP has expired
            if (existuser.OTP == null || existuser.OTPExpiration < DateTime.Now)
            {
                return new AuthenticationModel { Message = "OTP has expired. Please request a new one.", IsAuthenticated = false };
            }

            // Clear the OTP after successful verification
            existuser.OTP = null;
            existuser.OTPExpiration = DateTime.MinValue;
            existuser.LastOTPChecked = DateTime.Now;
            await _userManager.UpdateAsync(existuser);

            return new AuthenticationModel
            {
                Message = "OTP is correct. Now you need to reset your password.",
                IsAuthenticated = true,
                Token = model.Token,
                NumberOfLogin = existuser.NumberOfLogIn
            };

        }

        public async Task<PaginatedResult<AuthenticationGetDto>> GetAllUsersAsync(SieveModel sieveModel)
        {
            var query = _userManager.Users.AsQueryable();

            // Apply filter and sort only
            query = _sieveProcessor.Apply(sieveModel, query, applyPagination: false);

            var totalCount = await query.CountAsync();

            // Apply pagination only
            query = _sieveProcessor.Apply(sieveModel, query, applyFiltering: false, applySorting: false);

            var users = await query.ToListAsync();

            var userDtos = new List<AuthenticationGetDto>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var authDto = _mapper.Map<AuthenticationGetDto>(user);
                authDto.Roles = roles;
                if (!user.IsActive)
                {
                    if (user.IsDeleted)
                    {
                        authDto.Status = "Deleted";
                        authDto.Reason = "";
                    }
                    else if (user.IsFrozed && user.IsLocked)
                    {
                        authDto.Status = user.NumberOfLogIn == 0
                            ? "Frozen"
                            : "Locked & Frozen";
                        authDto.Reason = user.NumberOfLogIn == 0
                            ? "Number Of LogIn Zero Need OTP"
                            : "Try wrong password multiple times";

                    }
                    else if (user.IsFrozed)
                    {
                        authDto.Status = user.NumberOfLogIn == 0
                            ? "Frozen"
                            : "Frozen";
                        authDto.Reason = user.NumberOfLogIn == 0
                            ? "Number Of LogIn Zero"
                            : "Last LogIn A long Time Ago";

                    }
                    else if (user.IsLocked)
                    {
                        authDto.Status = "Locked";
                        authDto.Reason = "Try wrong password multiple times";
                    }
                }
                else {
                    authDto.Status = "Active";
                    authDto.Reason = "";

                }

                userDtos.Add(authDto);
            }
            return new PaginatedResult<AuthenticationGetDto>
            {
                Items = userDtos,
                TotalCount = totalCount,
                Page = sieveModel.Page ?? 1,
                PageSize = sieveModel.PageSize ?? totalCount
            };
         }
        public async Task<IEnumerable<string>> GetAllRolesAsync()
        {
            return await _roleManager.Roles.Select(r => r.Name).ToListAsync();
        }
        public async Task<AuthenticationGetDto> GetUserByCodeAsync(string code)
        {
            var user = await _userManager.Users.Where(x => x.Code.Equals(code)).FirstOrDefaultAsync();
            var existingRoles = await _userManager.GetRolesAsync(user);
            AuthenticationGetDto auth = _mapper.Map<AuthenticationGetDto>(user);
            auth.Roles = existingRoles;

            if (!user.IsActive)
            {
                if (user.IsDeleted)
                {
                    auth.Status = "Deleted";
                    auth.Reason = "";
                }
                else if (user.IsFrozed && user.IsLocked)
                {
                    auth.Status = user.NumberOfLogIn == 0
                        ? "Frozen"
                        : "Locked & Frozen";
                    auth.Reason = user.NumberOfLogIn == 0
                        ? "Number Of LogIn Zero Need OTP"
                        : "Try wrong password multiple times";

                }
                else if (user.IsFrozed)
                {
                    auth.Status = user.NumberOfLogIn == 0
                        ? "Frozen"
                        : "Frozen";
                    auth.Reason = user.NumberOfLogIn == 0
                        ? "Number Of LogIn Zero"
                        : "Last LogIn A long Time Ago";

                }
                else if (user.IsLocked)
                {
                    auth.Status = "Locked";
                    auth.Reason = "Try wrong password multiple times";
                }
            }
            else
            {
                auth.Status = "Active";
                auth.Reason = "";

            }

            return auth;
        }
        public async Task<UserWithRole> AssignRolesToUserAsync(string userCode, List<string> roles)
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
                    IsLocked = user.IsLocked,
                    IsActive = user.IsActive
                },
                Roles = userNewRoles
            };
        }
        public async Task<AuthenticationModel> ChangeUserStatusAsync(string userCode)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Code == userCode);
            if (user == null)
            {
                return new AuthenticationModel { Message = "User not found!", IsAuthenticated = false};
            }
            if (user.IsFrozed)
            {
                return new AuthenticationModel {
                    
                    Message = "User Frozen!",
                    IsAuthenticated = false,

                };
            }
            user.IsActive = !user.IsActive;
            if (user.IsActive && user.IsLocked)
            {
                user.IsLocked = false;
            }
            var result = await _userManager.UpdateAsync(user);

            return new AuthenticationModel{
                Message = "Status change successfully!",
                IsAuthenticated = true
            };            
        }
        public async Task<UserWithRole> AssignRoleToUserByServiceAsync(string userCode, string newRole)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Code == userCode);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            // Get user's existing roles
            var existingRoles = await _userManager.GetRolesAsync(user);
            if (existingRoles.Contains("SuperAdmin"))
            {
                throw new Exception("User is already a SuperAdmin and has all permissions by default.");
            }

            if (newRole == "SuperAdmin")
            {
                // Remove all roles
                var removeAllResult = await _userManager.RemoveFromRolesAsync(user, existingRoles);
                if (!removeAllResult.Succeeded)
                {
                    throw new Exception("Failed to remove all existing roles before assigning SuperAdmin.");
                }

                // Assign SuperAdmin role
                var addSuperAdminResult = await _userManager.AddToRoleAsync(user, "SuperAdmin");
                if (!addSuperAdminResult.Succeeded)
                {
                    throw new Exception("Failed to assign SuperAdmin role to user.");
                }
            }
            else
            {
                // Extract service name from the new role (before the '-')
                var newRoleParts = newRole.Split('-');
                if (newRoleParts.Length < 2)
                {
                    throw new Exception("Invalid role format. Expected format: 'ServiceName-RoleName'");
                }
                var newService = newRoleParts[0]; // Extract the service name (e.g., "CMS" from "CMS-Admin")

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
                    IsActive = user.IsActive,
                    IsLocked = user.IsLocked,
                },
                Roles = userNewRoles
            };
        }
        public async Task<AuthenticationModel> EditUserDepartment(string userCode, string newDepartment)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Code == userCode);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            user.Department = newDepartment;
            var result = await _userManager.UpdateAsync(user);

            return new AuthenticationModel
            {
                Message = "User has been created successfully.",
                Email = user.Email,
                IsAuthenticated = true,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };

        }
        public async Task<AuthenticationModel> UpdateUserAsync(UpdateUserDto newUser, string userCode)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Code == userCode);

            if (user == null)
                return new AuthenticationModel { Message = "User not found!",IsAuthenticated = false };

            string userName = (newUser.FirstName + newUser.LastName).Replace(" ", "");

            // Check if the provided password is correct before proceeding
            var passwordValid = await _userManager.CheckPasswordAsync(user, newUser.OldPassword);
            if (!passwordValid)
                return new AuthenticationModel { Message = "Incorrect old password!" , IsAuthenticated = false };

            if (await _userManager.FindByEmailAsync(newUser.Email) is not null)
                return new AuthenticationModel { Message = "Email is already exist!" , IsAuthenticated = false  };

            if (await _userManager.FindByNameAsync(userName) is not null)
                return new AuthenticationModel { Message = "Username is already exist!", IsAuthenticated = false };


            user.FirstName = newUser.FirstName;
            user.LastName = newUser.LastName;
            user.Email = newUser.Email;
            user.UserName = userName;

            // Change Password if provided
            if (!string.IsNullOrWhiteSpace(newUser.Password))
            {
                var passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                var passwordResult = await _userManager.ResetPasswordAsync(user, passwordResetToken, newUser.Password);

                if (!passwordResult.Succeeded)
                {
                    var errors = string.Join(", ", passwordResult.Errors.Select(e => e.Description));
                    return new AuthenticationModel
                    {
                        IsAuthenticated = false,
                        Message = $"Password update failed: {errors}"
                    };
                }
            }

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                var errors = string.Empty;

                foreach (var error in result.Errors)
                    errors += $"{error.Description},";

                return new AuthenticationModel
                {
                    IsAuthenticated = true,
                    Message = errors
                };
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
        public async Task<AuthenticationGetDto> UserFakeDeleteAsync(UserFakeDeleteDto dto)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Code == dto.Code);


            if (user != null)
            {
                user.IsDeleted = dto.IsDeleted;
                user.IsActive = user.IsFrozed = user.IsLocked = false;
               // Get all roles assigned to the user
               var roles = await _userManager.GetRolesAsync(user);

                // Remove user from all roles
                if (roles.Any())
                {
                    await _userManager.RemoveFromRolesAsync(user, roles);
                }

                await _userManager.UpdateAsync(user);
            }

            return _mapper.Map<AuthenticationGetDto>(user);
        }
        public async Task<AuthenticationModel> ForgotPassword(ForgotPasswordModel dto)
        {
            var existuser = await _userManager.FindByEmailAsync(dto.Email);

            if (existuser == null || existuser.IsDeleted)
            {
                return new AuthenticationModel { Message = "User not found!", IsAuthenticated = false };
            }
            var newPassword = GenerateSecurePassword();

            var hasPassword = await _userManager.HasPasswordAsync(existuser);
            if (hasPassword)
              await _userManager.RemovePasswordAsync(existuser);

            

            // Add the new password
            var addResult = await _userManager.AddPasswordAsync(existuser, newPassword);
            string subject = "Your Password Has Been Generated, Welcome to our website.";

            await _emailService.SendEmailAsync(dto.Email, subject, newPassword, existuser.FirstName);
            return new AuthenticationModel
            {
                IsAuthenticated = true,
                Message = "A new password has been sent to your email. Please check your inbox"
            };
        }


        public async Task<AuthenticationModel> SetUserManager(SetUserManagerDto dto)
        {
            var existuser = await _userManager.Users.FirstOrDefaultAsync(x => x.Code.Equals(dto.UserCode));
            var manager = await _userManager.Users.FirstOrDefaultAsync(x => x.Code.Equals(dto.ManagerCode));

            if (existuser == null || manager == null)
            {
                return new AuthenticationModel { Message = "User not found!", IsAuthenticated = false };
            }

            var roleHierarchy = new Dictionary<string, int>
            {
                { "Officer", 1 },
                { "Supervisor", 2 },
                { "Manager", 3 },
                { "Admin", 4 },
                { "SuperAdmin", 5 }
            };

            var existUserRoles = await _userManager.GetRolesAsync(existuser);
            var managerRoles = await _userManager.GetRolesAsync(manager);

            var userRoleMap = existUserRoles
                .Select(r => r.Split('-'))
                .Where(p => p.Length == 2 && roleHierarchy.ContainsKey(p[1]))
                .ToDictionary(p => p[0], p => roleHierarchy[p[1]]); // service => level

            var managerRoleMap = managerRoles
                .Select(r => r.Split('-'))
                .Where(p => p.Length == 2 && roleHierarchy.ContainsKey(p[1]))
                .ToDictionary(p => p[0], p => roleHierarchy[p[1]]); // service => level

            // Find common services
            var commonServices = userRoleMap.Keys.Intersect(managerRoleMap.Keys);

            // Check that manager's level is higher for all common services
            foreach (var service in commonServices)
            {
                if (managerRoleMap[service] <= userRoleMap[service])
                {
                    return new AuthenticationModel
                    {
                        Message = $"Manager must have a higher role than user for service '{service}'.",
                        IsAuthenticated = false
                    };
                }
            }

            existuser.ManagerCode = manager.Code;
            var result = await _userManager.UpdateAsync(existuser);

            return new AuthenticationModel
            {
                IsAuthenticated = true,
                Message = "A new password has been sent to your email. Please check your inbox"
            };
        }

        public async Task<AuthenticationModelWithClaims> DecryptToken([FromBody] string encryptedToken)
        {
            string privateKey = _configuration["JWT:Key"];


        public async Task<AuthenticationModel> AddB2BUserAsync(AddUserDto newuser)
        {
            string userName = (newuser.FirstName + newuser.LastName).Replace(" ", "");

            if (await _userManager.FindByEmailAsync(newuser.Email) is not null)
                return new AuthenticationModel { Message = "Email is already exist!", IsAuthenticated = false };

            if (await _userManager.FindByNameAsync(userName) is not null)
                return new AuthenticationModel { Message = "Username is already exist!", IsAuthenticated = false };

            var user = new ApplicationUser
            {
                Code = "User-" + Guid.NewGuid().ToString("N"),
                UserName = userName,
                Email = newuser.Email,
                FirstName = newuser.FirstName,
                LastName = newuser.LastName,
                IsLocked = false,
                IsActive = false,
                IsFrozed = true,
                LastOTPChecked = DateTime.MaxValue,
                LastLogIn = DateTime.MinValue,
                Department = newuser.Department,

            };
            var staticPassword = GenerateSecurePassword();
            var result = await _userManager.CreateAsync(user, staticPassword);

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
            /*
            // Iterate over each service and create roles for each
            foreach (var service in Enum.GetNames(typeof(Infrastructure.Domain.Consts.ServiceName)))
            {
                var roleName = $"{service}-Officer";
                await _userManager.AddToRoleAsync(user, roleName);
            }
            */
            var userRoles = await _userManager.GetRolesAsync(user);

            string subject = "Your Account Has Been Created, Welcome to our website.";

            await _emailService.SendEmailAsync(newuser.Email, subject, staticPassword, newuser.FirstName);


            return new AuthenticationModel
            {
                Message = "User has been created successfully.",
                Email = user.Email,
                Roles = userRoles,
                IsAuthenticated = true,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = null,
                Code = user.Code
            };
        }

        public async Task<bool> CheckEmail(string email)
        {
            return (await _userManager.FindByEmailAsync(email) is not null);
        }

    }
}


