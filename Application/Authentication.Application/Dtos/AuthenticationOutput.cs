using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Application.Dtos
{
    public class AuthenticationGetDto
    {
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }

        public string Email { get; set; }   

        public bool IsActive { get; set; }
        [MaxLength(50)]
        public string? Department { get; set; }

        public DateTime? LastLogIn { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
    
}
