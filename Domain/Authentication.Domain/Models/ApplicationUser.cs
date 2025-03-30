using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static Infrastructure.Domain.Consts;

namespace Authentication.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Code { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        public bool IsActive { get; set; } = true;
        public bool IsLocked { get; set; } = false;
        public bool IsFrozed { get; set; } = false;

        public int NumberOfLogIn { get; set; } = 0;

        [MaxLength(50)]
        public string? Department { get; set; }

        public DateTime? LastLogIn { get; set; }
        public string? OTP {  get; set; }
        public DateTime OTPExpiration {  get; set; }
        //info not used
        public string? MotherName { get; set; }
        public string? FatherName { get; set; }
        public Gender? Gender { get; set; }
        public string? IdentityNumber { get; set; }
        public bool IsDeleted { get; set; } = false;
    }


    public class GetUser
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public bool IsActive { get; set; }
        public bool IsLocked { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

    }

    public class UserWithRole
    {
        public GetUser applicationUser { get; set; }

        public IEnumerable<string> Roles { get; set; }

    }
}
