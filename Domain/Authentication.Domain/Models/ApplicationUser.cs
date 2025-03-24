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

        [MaxLength(50)]
        public string MotherName { get; set; }

        [MaxLength(50)]
        public string FatherName { get; set; }

        [MaxLength(50)]
        public string IdentityNumber { get; set; }

        [MaxLength(50)]
        public string PhoneNumber { get; set; }
        
        [MaxLength(50)]
        public Gender Gender { get; set; }

        public bool IsActive {  get; set; } = true;
        [MaxLength(50)]
        public string? Department { get; set; }

        public DateTime? LastLogIn { get; set; }
    }


    public class GetUser 
    {
         public int Id { get; set; }

         public string Code { get; set; }
        
         public bool IsActive {  get; set; }
        
         public string FirstName { get; set; }

         public string LastName { get; set; }

         public string MotherName { get; set; }

         public string FatherName { get; set; }

    }

    public class UserWithRole 
    {
        public GetUser applicationUser {  get; set; }

        public IEnumerable<string> Roles { get; set; }

    }
}
